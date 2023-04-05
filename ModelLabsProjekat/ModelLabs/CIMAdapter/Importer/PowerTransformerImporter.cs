using System;
using System.Collections.Generic;
using CIM.Model;
using FTN.Common;
using FTN.ESI.SIMES.CIM.CIMAdapter.Manager;

namespace FTN.ESI.SIMES.CIM.CIMAdapter.Importer
{
	/// <summary>
	/// PowerTransformerImporter
	/// </summary>
	public class PowerTransformerImporter
	{
		/// <summary> Singleton </summary>
		private static PowerTransformerImporter ptImporter = null;
		private static object singletoneLock = new object();

		private ConcreteModel concreteModel;
		private Delta delta;
		private ImportHelper importHelper;
		private TransformAndLoadReport report;


		#region Properties
		public static PowerTransformerImporter Instance
		{
			get
			{
				if (ptImporter == null)
				{
					lock (singletoneLock)
					{
						if (ptImporter == null)
						{
							ptImporter = new PowerTransformerImporter();
							ptImporter.Reset();
						}
					}
				}
				return ptImporter;
			}
		}

		public Delta NMSDelta
		{
			get 
			{
				return delta;
			}
		}
		#endregion Properties


		public void Reset()
		{
			concreteModel = null;
			delta = new Delta();
			importHelper = new ImportHelper();
			report = null;
		}

		public TransformAndLoadReport CreateNMSDelta(ConcreteModel cimConcreteModel)
		{
			LogManager.Log("Importing PowerTransformer Elements...", LogLevel.Info);
			report = new TransformAndLoadReport();
			concreteModel = cimConcreteModel;
			delta.ClearDeltaOperations();

			if ((concreteModel != null) && (concreteModel.ModelMap != null))
			{
				try
				{
					// convert into DMS elements
					ConvertModelAndPopulateDelta();
				}
				catch (Exception ex)
				{
					string message = string.Format("{0} - ERROR in data import - {1}", DateTime.Now, ex.Message);
					LogManager.Log(message);
					report.Report.AppendLine(ex.Message);
					report.Success = false;
				}
			}
			LogManager.Log("Importing PowerTransformer Elements - END.", LogLevel.Info);
			return report;
		}

		/// <summary>
		/// Method performs conversion of network elements from CIM based concrete model into DMS model.
		/// </summary>
		private void ConvertModelAndPopulateDelta()
		{
			LogManager.Log("Loading elements and creating delta...", LogLevel.Info);

			ImportReason();
			ImportProcess();
			ImportMarketDocument();
			ImportBidTimeSeries();
			ImportMeasurementPoint();

			LogManager.Log("Loading elements and creating delta completed.", LogLevel.Info);
		}

		#region Import
	
		private void ImportReason()
		{
			SortedDictionary<string, object> cimReasons = concreteModel.GetAllObjectsOfType("FTN.Reason");
			if (cimReasons != null)
			{
				foreach (KeyValuePair<string, object> cimReasonPair in cimReasons)
				{
					FTN.Reason cimReason = cimReasonPair.Value as FTN.Reason;

					ResourceDescription rd = CreateReasonResourceDescription(cimReason);
					if (rd != null)
					{
						delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
						report.Report.Append("Reason ID = ").Append(cimReason.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
					}
					else
					{
						report.Report.Append("Reason ID = ").Append(cimReason.ID).AppendLine(" FAILED to be converted");
					}
				}
				report.Report.AppendLine();
			}
		}

		private ResourceDescription CreateReasonResourceDescription(FTN.Reason cimReason)
		{
			ResourceDescription rd = null;
			if (cimReason != null)
			{
				long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.REASON, importHelper.CheckOutIndexForDMSType(DMSType.REASON));
				rd = new ResourceDescription(gid);
				importHelper.DefineIDMapping(cimReason.ID, gid);

				////populate ResourceDescription
				PowerTransformerConverter.PopulateReasonProperties(cimReason, rd);
			}
			return rd;
		}

		private void ImportProcess()
		{
			SortedDictionary<string, object> cimProcesses = concreteModel.GetAllObjectsOfType("FTN.Process");
			if (cimProcesses != null)
			{
				foreach (KeyValuePair<string, object> cimProcessPair in cimProcesses)
				{
					FTN.Process cimProcess = cimProcessPair.Value as FTN.Process;

					ResourceDescription rd = CreateProcessResourceDescription(cimProcess);
					if (rd != null)
					{
						delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
						report.Report.Append("Process ID = ").Append(cimProcess.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
					}
					else
					{
						report.Report.Append("Process ID = ").Append(cimProcess.ID).AppendLine(" FAILED to be converted");
					}
				}
				report.Report.AppendLine();
			}
		}

		private ResourceDescription CreateProcessResourceDescription(FTN.Process cimProcess)
		{
			ResourceDescription rd = null;
			if (cimProcess != null)
			{
				long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.PROCESS, importHelper.CheckOutIndexForDMSType(DMSType.PROCESS));
				rd = new ResourceDescription(gid);
				importHelper.DefineIDMapping(cimProcess.ID, gid);

				////populate ResourceDescription
				PowerTransformerConverter.PopulateProcessProperties(cimProcess, rd);
			}
			return rd;
		}

		private void ImportMarketDocument()
		{
			SortedDictionary<string, object> cimMarketDOCs = concreteModel.GetAllObjectsOfType("FTN.MarketDocument");
			if (cimMarketDOCs != null)
			{
				foreach (KeyValuePair<string, object> cimMarketDOCPair in cimMarketDOCs)
				{
					FTN.MarketDocument cimMarketDOC = cimMarketDOCPair.Value as FTN.MarketDocument;

					ResourceDescription rd = CreateMarketDocumentResourceDescription(cimMarketDOC);
					if (rd != null)
					{
						delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
						report.Report.Append("MarketDocument ID = ").Append(cimMarketDOC.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
					}
					else
					{
						report.Report.Append("MarketDocument ID = ").Append(cimMarketDOC.ID).AppendLine(" FAILED to be converted");
					}
				}
				report.Report.AppendLine();
			}
		}
		
		private ResourceDescription CreateMarketDocumentResourceDescription(FTN.MarketDocument cimMarketDOC)
		{
			ResourceDescription rd = null;
			if (cimMarketDOC != null)
			{
				long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.MARKETDOCUMENT, importHelper.CheckOutIndexForDMSType(DMSType.MARKETDOCUMENT));
				rd = new ResourceDescription(gid);
				importHelper.DefineIDMapping(cimMarketDOC.ID, gid);

				////populate ResourceDescription
				PowerTransformerConverter.PopulateMarketDocumentProperties(cimMarketDOC, rd, importHelper, report);
			}
			return rd;
		}

		private void ImportMeasurementPoint()
		{
			SortedDictionary<string, object> cimMPoints = concreteModel.GetAllObjectsOfType("FTN.MeasurementPoint");
			if (cimMPoints != null)
			{
				foreach (KeyValuePair<string, object> cimMPointsPair in cimMPoints)
				{
					FTN.MeasurementPoint cimMPoint = cimMPointsPair.Value as FTN.MeasurementPoint;

					ResourceDescription rd = CreateMeasurementPointResourceDescription(cimMPoint);
					if (rd != null)
					{
						delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
						report.Report.Append("MeasurementPoint ID = ").Append(cimMPoint.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
					}
					else
					{
						report.Report.Append("MeasurementPoint ID = ").Append(cimMPoint.ID).AppendLine(" FAILED to be converted");
					}
				}
				report.Report.AppendLine();
			}
		}

		private ResourceDescription CreateMeasurementPointResourceDescription(FTN.MeasurementPoint cimMPoint)
		{
			ResourceDescription rd = null;
			if (cimMPoint != null)
			{
				long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.MEASUREMENTPOINT, importHelper.CheckOutIndexForDMSType(DMSType.MEASUREMENTPOINT));
				rd = new ResourceDescription(gid);
				importHelper.DefineIDMapping(cimMPoint.ID, gid);

				////populate ResourceDescription
				PowerTransformerConverter.PopulateMeasurementPointProperties(cimMPoint, rd, importHelper, report);
			}
			return rd;
		}

		private void ImportBidTimeSeries()
		{
			SortedDictionary<string, object> cimBidTimeSerieses = concreteModel.GetAllObjectsOfType("FTN.BidTimeSeries");
			if (cimBidTimeSerieses != null)
			{
				foreach (KeyValuePair<string, object> cimBTimeSeriesPair in cimBidTimeSerieses)
				{
					FTN.BidTimeSeries cimBTimeSeries = cimBTimeSeriesPair.Value as FTN.BidTimeSeries;

					ResourceDescription rd = CreateBidTimeSeriesResourceDescription(cimBTimeSeries);
					if (rd != null)
					{
						delta.AddDeltaOperation(DeltaOpType.Insert, rd, true);
						report.Report.Append("BidTimeSeries ID = ").Append(cimBTimeSeries.ID).Append(" SUCCESSFULLY converted to GID = ").AppendLine(rd.Id.ToString());
					}
					else
					{
						report.Report.Append("BidTimeSeries ID = ").Append(cimBTimeSeries.ID).AppendLine(" FAILED to be converted");
					}
				}
				report.Report.AppendLine();
			}
		}

		private ResourceDescription CreateBidTimeSeriesResourceDescription(FTN.BidTimeSeries cimBTimeSeries)
		{
			ResourceDescription rd = null;
			if (cimBTimeSeries != null)
			{
				long gid = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.BIDTIMESERIES, importHelper.CheckOutIndexForDMSType(DMSType.BIDTIMESERIES));
				rd = new ResourceDescription(gid);
				importHelper.DefineIDMapping(cimBTimeSeries.ID, gid);

				////populate ResourceDescription
				PowerTransformerConverter.PopulateBidTimeSeriesProperties(cimBTimeSeries, rd, importHelper, report);
			}
			return rd;
		}

		#endregion Import
	}
}

