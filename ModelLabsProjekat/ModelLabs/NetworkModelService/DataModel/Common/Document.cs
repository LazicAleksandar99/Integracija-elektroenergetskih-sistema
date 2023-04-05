using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Common
{
    public class Document : IdentifiedObject
    {
		private DateTime createdDateTime;
		private float docStatus;
		private float electronicAddress;
		private DateTime lastModifiedDateTime;
		private string revisionNumber;
		private float status;
		private string subject;
		private string title;
		private string type;

		public Document(long globalId) : base(globalId)
		{
		}

		public DateTime CreatedDateTime
		{
			get
			{
				return createdDateTime;
			}

			set
			{
				createdDateTime = value;
			}
		}

		public float DocStatus
		{
			get
			{
				return docStatus;
			}

			set
			{
				docStatus = value;
			}
		}

		public float ElectronicAddress
		{
			get
			{
				return electronicAddress;
			}

			set
			{
				electronicAddress = value;
			}
		}

		public DateTime LastModifiedDateTime
		{
			get
			{
				return lastModifiedDateTime;
			}

			set
			{
				lastModifiedDateTime = value;
			}
		}

		public string RevisionNumber
		{
			get
			{
				return revisionNumber;
			}

			set
			{
				revisionNumber = value;
			}
		}

		public float Status
		{
			get
			{
				return status;
			}

			set
			{
				status = value;
			}
		}

		public string Subject
		{
			get
			{
				return subject;
			}

			set
			{
				subject = value;
			}
		}

		public string Title
		{
			get
			{
				return title;
			}

			set
			{
				title = value;
			}
		}


		public string Type
		{
			get
			{
				return type;
			}

			set
			{
				type = value;
			}
		}

		public override bool Equals(object obj)
		{
			if (base.Equals(obj))
			{
				Document x = (Document)obj;
				return ((x.createdDateTime == this.createdDateTime) &&
						(x.docStatus == this.docStatus) &&
						(x.electronicAddress == this.electronicAddress) &&
						(x.lastModifiedDateTime == this.lastModifiedDateTime) &&
						(x.revisionNumber == this.revisionNumber) &&
						(x.status == this.status) &&
						(x.subject == this.subject) &&
						(x.title == this.title) &&
						(x.type == this.type));
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
				case ModelCode.DOCUMENT_CRDATETIME:
				case ModelCode.DOCUMENT_DOCSTATUS:
				case ModelCode.DOCUMENT_ELADRESS:
				case ModelCode.DOCUMENT_LASTMODTIME:
				case ModelCode.DOCUMENT_REVNUMBER:
				case ModelCode.DOCUMENT_STATUS:
				case ModelCode.DOCUMENT_SUBJECT:
				case ModelCode.DOCUMENT_TITLE:
				case ModelCode.DOCUMENT_TYPE:
					return true;
				default:
					return base.HasProperty(property);
			}
		}

		public override void GetProperty(Property property)
		{
			switch (property.Id)
			{
				case ModelCode.DOCUMENT_CRDATETIME:
					property.SetValue(createdDateTime);
					break;

				case ModelCode.DOCUMENT_DOCSTATUS:
					property.SetValue(docStatus);
					break;
				case ModelCode.DOCUMENT_ELADRESS:
					property.SetValue(electronicAddress);
					break;

				case ModelCode.DOCUMENT_LASTMODTIME:
					property.SetValue(lastModifiedDateTime);
					break;
				case ModelCode.DOCUMENT_REVNUMBER:
					property.SetValue(revisionNumber);
					break;

				case ModelCode.DOCUMENT_STATUS:
					property.SetValue(status);
					break;
				case ModelCode.DOCUMENT_SUBJECT:
					property.SetValue(subject);
					break;

				case ModelCode.DOCUMENT_TITLE:
					property.SetValue(title);
					break;

				case ModelCode.DOCUMENT_TYPE:
					property.SetValue(type);
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
				case ModelCode.DOCUMENT_CRDATETIME:
					createdDateTime = property.AsDateTime();
					break;

				case ModelCode.DOCUMENT_DOCSTATUS:
					docStatus = property.AsFloat();
					break;

				case ModelCode.DOCUMENT_ELADRESS:
					electronicAddress = property.AsFloat();
					break;

				case ModelCode.DOCUMENT_LASTMODTIME:
					lastModifiedDateTime = property.AsDateTime();
					break;

				case ModelCode.DOCUMENT_REVNUMBER:
					revisionNumber = property.AsString();
					break;

				case ModelCode.DOCUMENT_STATUS:
					status = property.AsFloat();
					break;

				case ModelCode.DOCUMENT_SUBJECT:
					subject = property.AsString();
					break;

				case ModelCode.DOCUMENT_TITLE:
					title = property.AsString();
					break;

				case ModelCode.DOCUMENT_TYPE:
					type = property.AsString();
					break;

				default:
					base.SetProperty(property);
					break;
			}
		}

		#endregion IAccess implementation
	}
}
