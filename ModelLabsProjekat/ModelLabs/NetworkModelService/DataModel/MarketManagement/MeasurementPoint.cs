using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.MarketManagement
{
    public class MeasurementPoint : IdentifiedObject
	{
		private long timeSeries = 0;
		public MeasurementPoint (long globalId) : base(globalId)
		{

		}

		public long TimeSeries
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
				MeasurementPoint x = (MeasurementPoint)obj;
				return (x.timeSeries == this.timeSeries );
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
				case ModelCode.MEASUREMENTPOINT_TIMESR:
					return true;

				default:
					return base.HasProperty(property);
			}
		}

		public override void GetProperty(Property property)
		{
			switch (property.Id)
			{
				case ModelCode.MEASUREMENTPOINT_TIMESR:
					property.SetValue(timeSeries);
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
				case ModelCode.MEASUREMENTPOINT_TIMESR:
					timeSeries = property.AsReference();
					break;

				default:
					base.SetProperty(property);
					break;
			}
		}

		#endregion IAccess implementation

		#region IReference implementation

		public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
		{
			if (timeSeries != 0 && (refType == TypeOfReference.Reference || refType == TypeOfReference.Both))
			{
				references[ModelCode.MEASUREMENTPOINT_TIMESR] = new List<long>();
				references[ModelCode.MEASUREMENTPOINT_TIMESR].Add(timeSeries);
			}

			base.GetReferences(references, refType);
		}

		#endregion IReference implementation		
	}
}
