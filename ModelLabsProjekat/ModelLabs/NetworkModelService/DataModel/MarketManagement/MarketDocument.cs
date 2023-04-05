using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.MarketManagement
{
    public class MarketDocument : Document
    {
        private long reason = 0;
        private long process = 0;
        private List<long> timeSeries = new List<long>();

        public MarketDocument(long globalId) : base(globalId)
        {

        }

        public long Reason
        {
            get { return reason; }
            set { reason = value; }
        }

        public long Process
        {
            get { return process; }
            set { process = value; }
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
                MarketDocument x = (MarketDocument)obj;
                return (x.reason == this.reason &&
                        x.process == this.process &&
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
                case ModelCode.MARKETDOCUMENT_REASON:
                case ModelCode.MARKETDOCUMENT_PROCESS:
                case ModelCode.MARKETDOCUMENT_TIMESERIES:
                    return true;

                default:
                    return base.HasProperty(t);
            }
        }

        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {
                case ModelCode.MARKETDOCUMENT_REASON:
                    prop.SetValue(reason);
                    break;

                case ModelCode.MARKETDOCUMENT_PROCESS:
                    prop.SetValue(process);
                    break;
                case ModelCode.MARKETDOCUMENT_TIMESERIES:
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
                case ModelCode.MARKETDOCUMENT_REASON:
                    reason = property.AsReference();
                    break;

                case ModelCode.MARKETDOCUMENT_PROCESS:
                    process = property.AsReference();
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
                return timeSeries.Count > 0 || base.IsReferenced;
            }
        }
        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (timeSeries != null && timeSeries.Count > 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.MARKETDOCUMENT_TIMESERIES] = timeSeries.GetRange(0, timeSeries.Count);
            }

            if (reason != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.MARKETDOCUMENT_REASON] = new List<long>();
                references[ModelCode.MARKETDOCUMENT_REASON].Add(reason);
            }

            if (process != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.MARKETDOCUMENT_PROCESS] = new List<long>();
                references[ModelCode.MARKETDOCUMENT_PROCESS].Add(process);
            }

            base.GetReferences(references, refType);
        }

        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.TIMESERIES_MDOC:
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
                case ModelCode.TIMESERIES_MDOC:

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
