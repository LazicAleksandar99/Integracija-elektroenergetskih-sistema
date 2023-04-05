using FTN.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CreatingExampleModelsXML
{
    class Program
    {
        static void Main(string[] args)
        {
            var delta = new Delta();
          //  FTN.BidTimeSeries bs = new FTN.BidTimeSeries();

           // bs.StepIncrementQuantity = 0.3M;
            int reasons = 1;
            int processes = 1;
            int mDOCs = 1;
            int bTimeSeriess = 1;
            int mPoints = 1;

            for (int i = 0; i < 3; i++)
            {
                var reasonProps = new List<Property>
                {
                    new Property(ModelCode.IDOBJ_NAME,"reason"+i),
                    new Property(ModelCode.IDOBJ_MRID,"reason_mRID_"+i),
                    new Property(ModelCode.IDOBJ_ALIASNAME,"reason_alias_"+i),
                    new Property(ModelCode.REASON_CODE,"reason-"+i),
                    new Property(ModelCode.REASON_TEXT,"Thex for reason: "+i),
                };


                var reasonGID = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.REASON, -reasons);
                var reasonRD = new ResourceDescription(reasonGID, reasonProps);
                reasons++;

                var processProps = new List<Property>
                {
                    new Property(ModelCode.IDOBJ_NAME,"proces"+i),
                    new Property(ModelCode.IDOBJ_MRID,"proces_mRID_"+i),
                    new Property(ModelCode.IDOBJ_ALIASNAME,"proces_alias_"+i),
                    new Property(ModelCode.PROCESS_CLASSFICATIONTYPE,"proces-"+i),
                    new Property(ModelCode.PROCESS_PROCESSTYPE,"proces-type: "+i),
                };

                var processGID = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.PROCESS, -processes);
                var processRD = new ResourceDescription(processGID, processProps);
                processes++;

                for (int j = 0; j < 3; j++)
                {
                    var mDOCProps = new List<Property>
                    {
                        new Property(ModelCode.IDOBJ_NAME,"mDOC_"+ i +"_"+ j),
                        new Property(ModelCode.IDOBJ_MRID,"mDOC_mRID_"+ i +"_"+ j),
                        new Property(ModelCode.IDOBJ_ALIASNAME,"mDOC_alias_"+ i +"_"+ j),
                        new Property(ModelCode.DOCUMENT_CRDATETIME,DateTime.Now),
                        new Property(ModelCode.DOCUMENT_DOCSTATUS,(float)j),
                        new Property(ModelCode.DOCUMENT_ELADRESS,(float)j),
                        new Property(ModelCode.DOCUMENT_LASTMODTIME,DateTime.Now),
                        new Property(ModelCode.DOCUMENT_REVNUMBER,"mDOC revision num: "+i + "_" +j),
                        new Property(ModelCode.DOCUMENT_STATUS,(float)i),
                        new Property(ModelCode.DOCUMENT_TITLE,"mDOC-title-"+i + "_" +j),
                        new Property(ModelCode.DOCUMENT_TYPE,"mDOC-type-"+i + "_" +j),
                        new Property(ModelCode.MARKETDOCUMENT_REASON, reasonGID),
                        new Property(ModelCode.MARKETDOCUMENT_PROCESS, processGID),
                    };

                    var mDOCGID = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.MARKETDOCUMENT, -mDOCs);
                    var mDOCRD = new ResourceDescription(mDOCGID, mDOCProps);
                    mDOCs++;

                    for (int k = 0; k < 3; k++)
                    {
                        var bTimeSeriesProps = new List<Property>
                        {
                            new Property(ModelCode.IDOBJ_NAME,"bTimeSeries_"+ i +"_"+ j+"_"+k),
                            new Property(ModelCode.IDOBJ_MRID,"bTimeSeries_mRID_"+ i +"_"+ j+"_"+k),
                            new Property(ModelCode.IDOBJ_ALIASNAME,"bTimeSeries_alias_"+ i +"_"+ j+"_"+k),
                            new Property(ModelCode.TIMESERIES_OBJAGGR,"objectAGGR: "+ i +"_"+ j+"_"+k),
                            new Property(ModelCode.TIMESERIES_PRODUCT,"bidTimeSeries_product_"+ i +"_"+ j+"_"+k),
                            new Property(ModelCode.TIMESERIES_VERSION,"bitTimeSeries_version"+ i +"_"+ j+"_"+k),
                            new Property(ModelCode.TIMESERIES_REASON, reasonGID),
                            new Property(ModelCode.TIMESERIES_MDOC, mDOCGID),
                        };

                        var bTimeSeriesGID = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.BIDTIMESERIES, -bTimeSeriess);
                        var bTimeSeriesRD = new ResourceDescription(bTimeSeriesGID, bTimeSeriesProps);
                        bTimeSeriess++;

                        for (int l = 0; l < 3; l++)
                        {
                            var mPointProps = new List<Property>
                            {
                                new Property(ModelCode.IDOBJ_NAME,"mPoint_" + i + "_" + j + "_" + k + "_" + l),
                                new Property(ModelCode.IDOBJ_MRID,"mPoint_mRID_" + i + "_" + j + "_" + k + "_" + l),
                                new Property(ModelCode.IDOBJ_ALIASNAME,"mPoint_alias_" + i + "_" + j + "_" + k + "_" + l),
                                new Property(ModelCode.MEASUREMENTPOINT_TIMESR,bTimeSeriesGID),
                            };

                            var mPointGID = ModelCodeHelper.CreateGlobalId(0, (short)DMSType.MEASUREMENTPOINT, -mPoints);
                            var mPointRD = new ResourceDescription(mPointGID, mPointProps);
                            mPoints++;

                            delta.AddDeltaOperation(DeltaOpType.Insert, mPointRD, true);
                        }

                        delta.AddDeltaOperation(DeltaOpType.Insert, bTimeSeriesRD, true);
                    }

                    delta.AddDeltaOperation(DeltaOpType.Insert, mDOCRD, true);
                }

                delta.AddDeltaOperation(DeltaOpType.Insert, processRD, true);
                delta.AddDeltaOperation(DeltaOpType.Insert, reasonRD, true);
            }

            StreamWriter sw = new StreamWriter("allObj.xml");
            using (XmlTextWriter xmlText = new XmlTextWriter(sw))
            {
                xmlText.Formatting = Formatting.Indented;
                delta.ExportToXml(xmlText);
            }
        }
    }
}
