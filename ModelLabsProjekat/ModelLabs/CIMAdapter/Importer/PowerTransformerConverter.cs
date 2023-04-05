namespace FTN.ESI.SIMES.CIM.CIMAdapter.Importer
{
	using FTN.Common;

	/// <summary>
	/// PowerTransformerConverter has methods for populating
	/// ResourceDescription objects using PowerTransformerCIMProfile_Labs objects.
	/// </summary>
	public static class PowerTransformerConverter
	{

		#region Populate ResourceDescription
		public static void PopulateIdentifiedObjectProperties(FTN.IdentifiedObject cimIdentifiedObject, ResourceDescription rd)
		{
			if ((cimIdentifiedObject != null) && (rd != null))
			{
				if (cimIdentifiedObject.MRIDHasValue)
				{
					rd.AddProperty(new Property(ModelCode.IDOBJ_MRID, cimIdentifiedObject.MRID));
				}
				if (cimIdentifiedObject.NameHasValue)
				{
					rd.AddProperty(new Property(ModelCode.IDOBJ_NAME, cimIdentifiedObject.Name));
				}
				if (cimIdentifiedObject.AliasNameHasValue)
				{
					rd.AddProperty(new Property(ModelCode.IDOBJ_ALIASNAME, cimIdentifiedObject.AliasName));
				}
			}
		}

		public static void PopulateReasonProperties(FTN.Reason cimReason, ResourceDescription rd)
		{
			if ((cimReason != null) && (rd != null))
			{
				PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimReason, rd);

				if (cimReason.CodeHasValue)
				{
					rd.AddProperty(new Property(ModelCode.REASON_CODE, cimReason.Code));
				}
				if (cimReason.TextHasValue)
				{
					rd.AddProperty(new Property(ModelCode.REASON_TEXT, cimReason.Text));
				}
			}
		}

		public static void PopulateProcessProperties(FTN.Process cimProcess, ResourceDescription rd)
		{
			if ((cimProcess != null) && (rd != null))
			{
				PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimProcess, rd);

				if (cimProcess.ClassificationTypeHasValue)
				{
					rd.AddProperty(new Property(ModelCode.PROCESS_CLASSFICATIONTYPE, cimProcess.ClassificationType));
				}
				if (cimProcess.ProcessTypeHasValue)
				{
					rd.AddProperty(new Property(ModelCode.PROCESS_PROCESSTYPE, cimProcess.ProcessType));
				}
			}
		}

		public static void PopulateDocumentProperties(FTN.Document cimDocument, ResourceDescription rd)
		{
			if ((cimDocument != null) && (rd != null))
			{
				PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimDocument, rd);

				if (cimDocument.CreatedDateTimeHasValue)
				{
					rd.AddProperty(new Property(ModelCode.DOCUMENT_CRDATETIME, cimDocument.CreatedDateTime));
				}
				//if (cimDocument.DocStatusHasValue)
				//{
				//	rd.AddProperty(new Property(ModelCode.DOCUMENT_DOCSTATUS, cimDocument.DocStatus));
				//}
				//if (cimDocument.ElectronicAddressHasValue)
				//{
				//	rd.AddProperty(new Property(ModelCode.DOCUMENT_ELADRESS, cimDocument.ElectronicAddress));
				//}
				if (cimDocument.LastModifiedDateTimeHasValue)
				{
					rd.AddProperty(new Property(ModelCode.DOCUMENT_LASTMODTIME, cimDocument.LastModifiedDateTime));
				}
				if (cimDocument.RevisionNumberHasValue)
				{
					rd.AddProperty(new Property(ModelCode.DOCUMENT_REVNUMBER, cimDocument.RevisionNumber));
				}
				//if (cimDocument.StatusHasValue)
				//{
				//	rd.AddProperty(new Property(ModelCode.DOCUMENT_STATUS, cimDocument.Status));
				//}
				if (cimDocument.SubjectHasValue)
				{
					rd.AddProperty(new Property(ModelCode.DOCUMENT_SUBJECT, cimDocument.Subject));
				}
				if (cimDocument.TitleHasValue)
				{
					rd.AddProperty(new Property(ModelCode.DOCUMENT_TITLE, cimDocument.Title));
				}
				if (cimDocument.TypeHasValue)
				{
					rd.AddProperty(new Property(ModelCode.DOCUMENT_TYPE, cimDocument.Type));
				}
			}
		}

		public static void PopulateMarketDocumentProperties(FTN.MarketDocument cimMarketDOC, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimMarketDOC != null) && (rd != null))
			{
				PowerTransformerConverter.PopulateDocumentProperties(cimMarketDOC, rd);

				if (cimMarketDOC.ProcessHasValue)
                {
                    long gid = importHelper.GetMappedGID(cimMarketDOC.Process.ID);
                    if (gid < 0)
                    {
                        report.Report.Append("WARNING: Convert ").	Append(cimMarketDOC.GetType().ToString()).Append(" rdfID = \"").Append(cimMarketDOC.ID);
                        report.Report.Append("\" - Failed to set reference to Process: rdfID \"").Append(cimMarketDOC.Process.ID).AppendLine(" \" is not mapped to GID!");
                    }
                    rd.AddProperty(new Property(ModelCode.MARKETDOCUMENT_PROCESS, gid));
                }
				if (cimMarketDOC.ReasonHasValue)
				{
					long gid = importHelper.GetMappedGID(cimMarketDOC.Reason.ID);
					if (gid < 0)
					{
						report.Report.Append("WARNING: Convert ").Append(cimMarketDOC.GetType().ToString()).Append(" rdfID = \"").Append(cimMarketDOC.ID);
						report.Report.Append("\" - Failed to set reference to Reason: rdfID \"").Append(cimMarketDOC.Reason.ID).AppendLine(" \" is not mapped to GID!");
					}
					rd.AddProperty(new Property(ModelCode.MARKETDOCUMENT_REASON, gid));
				}
			}
		}

        public static void PopulateTimeSeriesProperties(FTN.TimeSeries cimTimeSeries, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
        {
            if ((cimTimeSeries != null) && (rd != null))
            {
                PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimTimeSeries, rd);

                if (cimTimeSeries.ObjectAggregationHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.TIMESERIES_OBJAGGR, cimTimeSeries.ObjectAggregation));
                }
                if (cimTimeSeries.ProductHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.TIMESERIES_PRODUCT, cimTimeSeries.Product));
                }
                if (cimTimeSeries.VersionHasValue)
                {
                    rd.AddProperty(new Property(ModelCode.TIMESERIES_VERSION, cimTimeSeries.Version));
                }
                if (cimTimeSeries.ReasonHasValue)
                {
					long gid = importHelper.GetMappedGID(cimTimeSeries.Reason.ID);
					if (gid < 0)
					{
						report.Report.Append("WARNING: Convert ").Append(cimTimeSeries.GetType().ToString()).Append(" rdfID = \"").Append(cimTimeSeries.ID);
						report.Report.Append("\" - Failed to set reference to Process: rdfID \"").Append(cimTimeSeries.Reason.ID).AppendLine(" \" is not mapped to GID!");
					}
					rd.AddProperty(new Property(ModelCode.TIMESERIES_REASON, gid));
				}
				if (cimTimeSeries.MarketDocumentHasValue)
				{
					long gid = importHelper.GetMappedGID(cimTimeSeries.MarketDocument.ID);
					if (gid < 0)
					{
						report.Report.Append("WARNING: Convert ").Append(cimTimeSeries.GetType().ToString()).Append(" rdfID = \"").Append(cimTimeSeries.ID);
						report.Report.Append("\" - Failed to set reference to Process: rdfID \"").Append(cimTimeSeries.MarketDocument.ID).AppendLine(" \" is not mapped to GID!");
					}
					rd.AddProperty(new Property(ModelCode.TIMESERIES_MDOC, gid));
				}
			}
        }

        public static void PopulateMeasurementPointProperties(FTN.MeasurementPoint cimMPoint, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimMPoint != null) && (rd != null))
			{
				PowerTransformerConverter.PopulateIdentifiedObjectProperties(cimMPoint, rd);

				if (cimMPoint.TimeSeriesHasValue)
				{
					long gid = importHelper.GetMappedGID(cimMPoint.TimeSeries.ID);
					if (gid < 0)
					{
						report.Report.Append("WARNING: Convert ").Append(cimMPoint.GetType().ToString()).Append(" rdfID = \"").Append(cimMPoint.ID);
						report.Report.Append("\" - Failed to set reference to TimeSeries: rdfID \"").Append(cimMPoint.TimeSeries.ID).AppendLine(" \" is not mapped to GID!");
					}
					rd.AddProperty(new Property(ModelCode.MEASUREMENTPOINT_TIMESR, gid));
				}
			}
		}
		
		public static void PopulateBidTimeSeriesProperties(FTN.BidTimeSeries cimBTimeSeries, ResourceDescription rd, ImportHelper importHelper, TransformAndLoadReport report)
		{
			if ((cimBTimeSeries != null) && (rd != null))
			{
				PowerTransformerConverter.PopulateTimeSeriesProperties(cimBTimeSeries, rd, importHelper, report);

				if (cimBTimeSeries.BlockBidHasValue)
				{
					rd.AddProperty(new Property(ModelCode.BIDTIMESERIES_BLOCKBID, cimBTimeSeries.BlockBid));
				}
				if (cimBTimeSeries.DirectionHasValue)
				{
					rd.AddProperty(new Property(ModelCode.BIDTIMESERIES_DIRECTION, cimBTimeSeries.Direction));
				}
				if (cimBTimeSeries.DivisibleHasValue)
				{
					rd.AddProperty(new Property(ModelCode.BIDTIMESERIES_DIVISIBLE, cimBTimeSeries.Divisible));
				}
				if (cimBTimeSeries.LinkedBidsIdentificationHasValue)
				{
					rd.AddProperty(new Property(ModelCode.BIDTIMESERIES_LINKBIDID, cimBTimeSeries.LinkedBidsIdentification));
				}
				
			}
		}

		#endregion Populate ResourceDescription

		#region Enums convert
		//public static PhaseCode GetDMSPhaseCode(FTN.PhaseCode phases)
		//{
		//	switch (phases)
		//	{
		//		case FTN.PhaseCode.A:
		//			return PhaseCode.A;
		//		case FTN.PhaseCode.AB:
		//			return PhaseCode.AB;
		//		case FTN.PhaseCode.ABC:
		//			return PhaseCode.ABC;
		//		case FTN.PhaseCode.ABCN:
		//			return PhaseCode.ABCN;
		//		case FTN.PhaseCode.ABN:
		//			return PhaseCode.ABN;
		//		case FTN.PhaseCode.AC:
		//			return PhaseCode.AC;
		//		case FTN.PhaseCode.ACN:
		//			return PhaseCode.ACN;
		//		case FTN.PhaseCode.AN:
		//			return PhaseCode.AN;
		//		case FTN.PhaseCode.B:
		//			return PhaseCode.B;
		//		case FTN.PhaseCode.BC:
		//			return PhaseCode.BC;
		//		case FTN.PhaseCode.BCN:
		//			return PhaseCode.BCN;
		//		case FTN.PhaseCode.BN:
		//			return PhaseCode.BN;
		//		case FTN.PhaseCode.C:
		//			return PhaseCode.C;
		//		case FTN.PhaseCode.CN:
		//			return PhaseCode.CN;
		//		case FTN.PhaseCode.N:
		//			return PhaseCode.N;
		//		case FTN.PhaseCode.s12N:
		//			return PhaseCode.ABN;
		//		case FTN.PhaseCode.s1N:
		//			return PhaseCode.AN;
		//		case FTN.PhaseCode.s2N:
		//			return PhaseCode.BN;
		//		default: return PhaseCode.Unknown;
		//	}
		//}

		//public static TransformerFunction GetDMSTransformerFunctionKind(FTN.TransformerFunctionKind transformerFunction)
		//{
		//	switch (transformerFunction)
		//	{
		//		case FTN.TransformerFunctionKind.voltageRegulator:
		//			return TransformerFunction.Voltreg;
		//		default:
		//			return TransformerFunction.Consumer;
		//	}
		//}

		//public static WindingType GetDMSWindingType(FTN.WindingType windingType)
		//{
		//	switch (windingType)
		//	{
		//		case FTN.WindingType.primary:
		//			return WindingType.Primary;
		//		case FTN.WindingType.secondary:
		//			return WindingType.Secondary;
		//		case FTN.WindingType.tertiary:
		//			return WindingType.Tertiary;
		//		default:
		//			return WindingType.None;
		//	}
		//}

		//public static WindingConnection GetDMSWindingConnection(FTN.WindingConnection windingConnection)
		//{
		//	switch (windingConnection)
		//	{
		//		case FTN.WindingConnection.D:
		//			return WindingConnection.D;
		//		case FTN.WindingConnection.I:
		//			return WindingConnection.I;
		//		case FTN.WindingConnection.Z:
		//			return WindingConnection.Z;
		//		case FTN.WindingConnection.Y:
		//			return WindingConnection.Y;
		//		default:
		//			return WindingConnection.Y;
		//	}
		//}
		#endregion Enums convert
	}
}
