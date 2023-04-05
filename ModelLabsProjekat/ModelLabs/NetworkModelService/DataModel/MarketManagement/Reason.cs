using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.MarketManagement
{
    public class Reason : IdentifiedObject
    {
        private string code = string.Empty;
        private string text = string.Empty;
        private List<long> marketDocument = new List<long>();
        private List<long> timeSeries = new List<long>();

        public Reason(long globalId) : base(globalId)
        {

        }

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public List<long> MarketDocument
        {
            get
            {
                return marketDocument;
            }

            set
            {
                marketDocument = value;
            }
        }

        public List<long> TimeSeries
        {
            get
            {
                return timeSeries;
            }

            set
            {
                timeSeries = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                Reason x = (Reason)obj;
                return (x.code == this.code && 
                        x.text == this.text &&
                        CompareHelper.CompareLists(x.marketDocument, this.marketDocument, true) &&
                        CompareHelper.CompareLists(x.timeSeries, this.timeSeries, true));
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #region IAccess implementation

        public override bool HasProperty(ModelCode t)
        {
            switch (t)
            {
                case ModelCode.REASON_CODE:
                case ModelCode.REASON_TEXT:
                case ModelCode.REASON_MDOC:
                case ModelCode.REASON_TIMESERIES:
                    return true;

                default:
                    return base.HasProperty(t);
            }
        }

        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {
                case ModelCode.REASON_CODE:
                    prop.SetValue(code);
                    break;

                case ModelCode.REASON_TEXT:
                    prop.SetValue(text);
                    break;
                case ModelCode.REASON_MDOC:
                    prop.SetValue(marketDocument);
                    break;

                case ModelCode.REASON_TIMESERIES:
                    prop.SetValue(timeSeries);
                    break;

                default:
                    base.GetProperty(prop);
                    break;
            }
        }
        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.REASON_CODE:
                    code = property.AsString();
                    break;

                case ModelCode.REASON_TEXT:
                    text = property.AsString();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation

        #region IReference implementation

        public override bool IsReferenced
        {
            get
            {
                return marketDocument.Count > 0 || timeSeries.Count > 0 || base.IsReferenced;
            }
        }
        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (marketDocument != null && marketDocument.Count > 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.REASON_MDOC] = marketDocument.GetRange(0, marketDocument.Count);
            }

            if (timeSeries != null && timeSeries.Count > 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.REASON_TIMESERIES] = timeSeries.GetRange(0, timeSeries.Count);
            }

            base.GetReferences(references, refType);
        }

        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.MARKETDOCUMENT_REASON:
                    marketDocument.Add(globalId);
                    break;
                case ModelCode.TIMESERIES_REASON:
                    timeSeries.Add(globalId);
                    break;

                default:
                    base.AddReference(referenceId, globalId);
                    break;
            }
        }

        public override void RemoveReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.MARKETDOCUMENT_REASON:

                    if (marketDocument.Contains(globalId))
                    {
                        marketDocument.Remove(globalId);
                    }
                    else
                    {
                        CommonTrace.WriteTrace(CommonTrace.TraceWarning, "Entity (GID = 0x{0:x16}) doesn't contain reference 0x{1:x16}.", this.GlobalId, globalId);
                    }

                    break;

                case ModelCode.TIMESERIES_REASON:

                    if (timeSeries.Contains(globalId))
                    {
                        timeSeries.Remove(globalId);
                    }
                    else
                    {
                        CommonTrace.WriteTrace(CommonTrace.TraceWarning, "Entity (GID = 0x{0:x16}) doesn't contain reference 0x{1:x16}.", this.GlobalId, globalId);
                    }

                    break;

                default:
                    base.RemoveReference(referenceId, globalId);
                    break;
            }
        }

        #endregion IReference implementation

    }
}
