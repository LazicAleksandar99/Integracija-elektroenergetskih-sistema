using FTN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.MarketManagement
{
    public class BidTimeSeries : TimeSeries
    {
        private bool blockBid;
        private string direction;
        private bool divisible;
        private string linkedBidsIdentification;

        public BidTimeSeries(long globalId) : base(globalId)
        {

        }

        public bool BlockBid { get => blockBid; set => blockBid = value; }
        public string Direction { get => direction; set => direction = value; }
        public bool Divisible { get => divisible; set => divisible = value; }
        public string LinkedBidsIdentification { get => linkedBidsIdentification; set => linkedBidsIdentification = value; }
		public override bool Equals(object obj)
		{
			if (base.Equals(obj))
			{
				BidTimeSeries x = (BidTimeSeries)obj;
				return ((x.blockBid == this.blockBid) &&
						(x.direction == this.direction) &&
						(x.divisible == this.divisible) &&
						(x.linkedBidsIdentification == this.linkedBidsIdentification));
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

		public override bool HasProperty(ModelCode property)
		{
			switch (property)
			{
				case ModelCode.BIDTIMESERIES_BLOCKBID:
				case ModelCode.BIDTIMESERIES_DIRECTION:
				case ModelCode.BIDTIMESERIES_DIVISIBLE:
				case ModelCode.BIDTIMESERIES_LINKBIDID:
					return true;
				default:
					return base.HasProperty(property);
			}
		}

		public override void GetProperty(Property property)
		{
			switch (property.Id)
			{
				case ModelCode.BIDTIMESERIES_BLOCKBID:
					property.SetValue(blockBid);
					break;

				case ModelCode.BIDTIMESERIES_DIRECTION:
					property.SetValue(direction);
					break;
				case ModelCode.BIDTIMESERIES_DIVISIBLE:
					property.SetValue(divisible);
					break;

				case ModelCode.BIDTIMESERIES_LINKBIDID:
					property.SetValue(linkedBidsIdentification);
					break;

				default:
					base.GetProperty(property);
					break;
			}
		}

		public override void SetProperty(Property property)
		{
			switch (property.Id)
			{
				case ModelCode.BIDTIMESERIES_BLOCKBID:
					blockBid = property.AsBool();
					break;

				case ModelCode.BIDTIMESERIES_DIRECTION:
					direction = property.AsString();
					break;

				case ModelCode.BIDTIMESERIES_DIVISIBLE:
					divisible = property.AsBool();
					break;

				case ModelCode.BIDTIMESERIES_LINKBIDID:
					linkedBidsIdentification = property.AsString();
					break;

				default:
					base.SetProperty(property);
					break;
			}
		}

		#endregion IAccess implementation
	}
}
