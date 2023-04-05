using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.MarketManagement
{
    public class TimeSeries : IdentifiedObject
    {
        private string objectAggregation;
        private string product;
        private string version;
        private long reason = 0;
        private long marketDocument = 0;
        private List<long> measurementPoint = new List<long>();

        public TimeSeries(long globalId) : base(globalId)
        {

        }

        public long Reason
        {
            get { return reason; }
            set { reason = value; }
        }

        public long MarketDocument
        {
            get { return marketDocument; }
            set { marketDocument = value; }
        }

        public List<long> MeasurementPoint
        {
            get
            {
                return measurementPoint;
            }

            set
            {
                measurementPoint = value;
            }
        }
        public string ObjectAggregation { get => objectAggregation; set => objectAggregation = value; }
        public string Product { get => product; set => product = value; }
        public string Version { get => version; set => version = value; }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                TimeSeries x = (TimeSeries)obj;
                return (x.objectAggregation == this.objectAggregation &&
                        x.product == this.product &&
                        x.version == this.version &&
                        x.reason == this.reason &&
                        x.marketDocument == this.marketDocument &&
                        CompareHelper.CompareLists(x.measurementPoint, this.measurementPoint, true));
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
                case ModelCode.TIMESERIES_OBJAGGR:
                case ModelCode.TIMESERIES_PRODUCT:
                case ModelCode.TIMESERIES_VERSION:
                case ModelCode.TIMESERIES_REASON:
                case ModelCode.TIMESERIES_MDOC:
                case ModelCode.TIMESERIES_MPOINT:
                    return true;

                default:
                    return base.HasProperty(t);
            }
        }

        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {
                case ModelCode.TIMESERIES_OBJAGGR:
                    prop.SetValue(objectAggregation);
                    break;
                case ModelCode.TIMESERIES_PRODUCT:
                    prop.SetValue(product);
                    break;
                case ModelCode.TIMESERIES_VERSION:
                    prop.SetValue(version);
                    break;
                case ModelCode.TIMESERIES_REASON:
                    prop.SetValue(reason);
                    break;
                case ModelCode.TIMESERIES_MDOC:
                    prop.SetValue(marketDocument);
                    break;
                case ModelCode.TIMESERIES_MPOINT:
                    prop.SetValue(measurementPoint);
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
                case ModelCode.TIMESERIES_OBJAGGR:
                    objectAggregation = property.AsString();
                    break;

                case ModelCode.TIMESERIES_PRODUCT:
                    product = property.AsString();
                    break;

                case ModelCode.TIMESERIES_VERSION:
                    version = property.AsString();
                    break;

                case ModelCode.TIMESERIES_REASON:
                    reason = property.AsReference();
                    break;

                case ModelCode.TIMESERIES_MDOC:
                    marketDocument = property.AsReference();
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
                return measurementPoint.Count > 0 || base.IsReferenced;
            }
        }


        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (measurementPoint != null && measurementPoint.Count > 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.TIMESERIES_MPOINT] = measurementPoint.GetRange(0, measurementPoint.Count);
            }

            if (reason != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.TIMESERIES_REASON] = new List<long>();
                references[ModelCode.TIMESERIES_REASON].Add(reason);
            }

            if (marketDocument != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
            {
                references[ModelCode.TIMESERIES_MDOC] = new List<long>();
                references[ModelCode.TIMESERIES_MDOC].Add(marketDocument);
            }

            base.GetReferences(references, refType);
        }

        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.MEASUREMENTPOINT_TIMESR:
                    measurementPoint.Add(globalId);
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
                case ModelCode.MEASUREMENTPOINT_TIMESR:

                    if (measurementPoint.Contains(globalId))
                    {
                        measurementPoint.Remove(globalId);
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
