using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.MarketManagement
{
    public class Process : IdentifiedObject
    {
        private string classificationType = string.Empty;
        private string processType = string.Empty;
        private List<long> marketDocument = new List<long>();

        public Process(long globalId) : base(globalId)
        {

        }

        public string ClassificationType
        {
            get { return classificationType; }
            set { classificationType = value; }
        }

        public string ProcessType
        {
            get { return processType; }
            set { processType = value; }
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

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                Process x = (Process)obj;
                return (x.classificationType == this.classificationType &&
                        x.processType == this.processType &&
                        CompareHelper.CompareLists(x.marketDocument, this.marketDocument, true));
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
                case ModelCode.PROCESS_CLASSFICATIONTYPE:
                case ModelCode.PROCESS_PROCESSTYPE:
                case ModelCode.PROCESS_MDOC:
                    return true;

                default:
                    return base.HasProperty(t);
            }
        }

        public override void GetProperty(Property prop)
        {
            switch (prop.Id)
            {
                case ModelCode.PROCESS_CLASSFICATIONTYPE:
                    prop.SetValue(classificationType);
                    break;

                case ModelCode.PROCESS_PROCESSTYPE:
                    prop.SetValue(processType);
                    break;

                case ModelCode.PROCESS_MDOC:
                    prop.SetValue(marketDocument);
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
                case ModelCode.PROCESS_CLASSFICATIONTYPE:
                    classificationType = property.AsString();
                    break;

                case ModelCode.PROCESS_PROCESSTYPE:
                    processType = property.AsString();
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
                return marketDocument.Count > 0 || base.IsReferenced;
            }
        }
        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            if (marketDocument != null && marketDocument.Count > 0 && (refType == TypeOfReference.Target || refType == TypeOfReference.Both))
            {
                references[ModelCode.PROCESS_MDOC] = marketDocument.GetRange(0, marketDocument.Count);
            }

            base.GetReferences(references, refType);
        }

        public override void AddReference(ModelCode referenceId, long globalId)
        {
            switch (referenceId)
            {
                case ModelCode.MARKETDOCUMENT_PROCESS:
                    marketDocument.Add(globalId);
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
                case ModelCode.MARKETDOCUMENT_PROCESS:

                    if (marketDocument.Contains(globalId))
                    {
                        marketDocument.Remove(globalId);
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
