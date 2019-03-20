using System;

namespace DataHubAPIClient.DataHubAPIResponse
{
    /// <summary>
    /// Defines Employee Department Object
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Gets or sets Department Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Gets or sets Department Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets Department ShortName
        /// </summary>
        public string ShortName { get; set; }
        /// <summary>
        /// Gets or sets Cost Center
        /// </summary>
        public string CostCenter { get; set; }
        /// <summary>
        /// Gets or sets Business Segment
        /// </summary>
        public string BusinessSegment { get; set; }
        /// <summary>
        /// Gets or sets Business Segment Name
        /// </summary>
        public string BusinessSegmentName { get; set; }
        /// <summary>
        /// Gets or sets LocationCode
        /// </summary>
        public string LocationCode { get; set; }
        /// <summary>
        /// Gets or sets Location Name
        /// </summary>
        public string LocationName { get; set; }
        /// <summary>
        /// Gets or sets Location Short Name
        /// </summary>
        public string LocationShortName { get; set; }
        /// <summary>
        /// Gets or sets Address Line 1
        /// </summary>
        public string AddressLine1 { get; set; }
        /// <summary>
        /// Gets or sets Address Line 2
        /// </summary>
        public string AddressLine2 { get; set; }
        /// <summary>
        /// Gets or sets City
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Gets or sets State
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// Gets or sets Zip
        /// </summary>
        public string Zip { get; set; }
        /// <summary>
        /// Gets or sets Country
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// Gets or sets County
        /// </summary>
        public string County { get; set; }
        /// <summary>
        /// Gets or sets Function Code
        /// </summary>
        public string FunctionCode { get; set; }
        /// <summary>
        /// Gets or sets Function name
        /// </summary>
        public string FunctionName { get; set; }
        /// <summary>
        /// Gets or sets Division Code
        /// </summary>
        public string DivisionCode { get; set; }
        /// <summary>
        /// Gets or sets Division Name
        /// </summary>
        public string DivisionName { get; set; }
        /// <summary>
        /// Gets or sets Ferc Status
        /// </summary>
        public string FercStatus { get; set; }
        /// <summary>
        /// Gets or sets Ferc Status Description
        /// </summary>
        public string FercStatusDescription { get; set; }
    }
    /// <summary>
    /// Describes the Employee Object
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets Employee Id
        /// </summary>
        public string EmployeeId { get; set; }
        /// <summary>
        /// Gets or sets Full Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets Last Name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Gets or sets First Name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Gets or sets Middle name
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Gets or sets Name Suffix
        /// </summary>
        public string NameSuffix { get; set; }
        /// <summary>
        /// Gets or sets Preferred First Name
        /// </summary>
        public string PreferredFirstName { get; set; }
        /// <summary>
        /// Gets or sets Consultant Company
        /// </summary>
        public string ConsultantCompany { get; set; }
        /// <summary>
        /// Gets or sets Mail Drop
        /// </summary>
        public string MailDrop { get; set; }
        /// <summary>
        /// Gets or sets Status
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// Gets or sets Union Flag
        /// </summary>
        public bool UnionFlag { get; set; }
        /// <summary>
        /// Gets or sets Consultant Flag
        /// </summary>
        public bool ConsultantFlag { get; set; }
        /// <summary>
        /// Gets or sets Work Phone
        /// </summary>
        public string WorkPhone { get; set; }
        /// <summary>
        /// Gets or sets Work Extension
        /// </summary>
        public string WorkExtension { get; set; }
        /// <summary>
        /// Gets or sets Work Phone 2
        /// </summary>
        public string WorkPhone2 { get; set; }
        /// <summary>
        /// Gets or sets Pager
        /// </summary>
        public string Pager { get; set; }
        /// <summary>
        /// Gets or sets Cell Phone
        /// </summary>
        public string CellPhone { get; set; }
        /// <summary>
        /// Gets or sets Fax
        /// </summary>
        public string Fax { get; set; }
        /// <summary>
        /// Gets or sets Room Number
        /// </summary>
        public string RoomNbr { get; set; }
        /// <summary>
        /// Gets or sets email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Gets or sets Original Hire Date
        /// </summary>
        public string OriginalHireDate { get; set; }
        /// <summary>
        /// Gets or sets Status Effective Date
        /// </summary>
        public string StatusEffectiveDate { get; set; }
        /// <summary>
        /// Gets or sets Callaway Pin
        /// </summary>
        public string CallawayPin { get; set; }
        /// <summary>
        /// Gets or sets Full or Part Time Code
        /// </summary>
        public string FullPartTimeCode { get; set; }
        /// <summary>
        /// Gets or sets Regular or Temp Code
        /// </summary>
        public string RegularTempCode { get; set; }
        /// <summary>
        /// Gets or sets EmployeeTypeName
        /// </summary>
        public string EmployeeTypeName { get; set; }
        /// <summary>
        /// Gets or sets Job Last Updated
        /// </summary>
        public string JobLastUpdated { get; set; }
        /// <summary>
        /// Gets or sets Supervisor Id
        /// </summary>
        public string SupervisorId { get; set; }
        /// <summary>
        /// Gets or sets Supervisor Full Name
        /// </summary>
        public string SupervisorName { get; set; }
        /// <summary>
        /// Gets or sets Supervisor Last Name
        /// </summary>
        public string SupervisorLastName { get; set; }
        /// <summary>
        /// Gets or sets Supervisor First Name
        /// </summary>
        public string SupervisorFirstName { get; set; }
        /// <summary>
        /// Gets or sets Job Description Code
        /// </summary>
        public string JobCodeDescription { get; set; }
        /// <summary>
        /// Gets or sets Job Code
        /// </summary>
        public string JobCode { get; set; }
        /// <summary>
        /// Gets or sets Job Family
        /// </summary>
        public string JobFamily { get; set; }
        /// <summary>
        /// Gets or sets Company Code
        /// </summary>
        public string CompanyCode { get; set; }
        /// <summary>
        /// Gets or sets Job Family Description
        /// </summary>
        public string JobFamilyDescription { get; set; }
        /// <summary>
        /// Gets or sets Employee Type Code
        /// </summary>
        public string EmployeeTypeCode { get; set; }
        /// <summary>
        /// Gets or sets Requisition Approval Amount
        /// </summary>
        public string RequisitionApprovalAmount { get; set; }
        /// <summary>
        /// Gets or sets Supervisor Flag
        /// </summary>
        public bool SupervisorFlag { get; set; }
        /// <summary>
        /// Gets or sets Pay Group
        /// </summary>
        public string PayGroupName { get; set; }
        /// <summary>
        /// Gets or sets Pay Group Code
        /// </summary>
        public string PayGroupCode { get; set; }
        /// <summary>
        /// Gets or sets Union Code
        /// </summary>
        public string UnionCode { get; set; }
        /// <summary>
        /// Gets or sets Union Description
        /// </summary>
        public string UnionDescription { get; set; }
        /// <summary>
        /// Gets or sets Job Effective Date
        /// </summary>
        public string JobEffectiveDate { get; set; }
        /// <summary>
        /// Gets or sets Job Action
        /// </summary>
        public string JobAction { get; set; }
        /// <summary>
        /// Gets or sets Job Action Reason
        /// </summary>
        public string JobActionReason { get; set; }
        /// <summary>
        /// Gets or sets Department Last Updated
        /// </summary>
        public string DepartmentLastUpdated { get; set; }
        /// <summary>
        /// Gets or sets Job Code Last Updated
        /// </summary>
        public string JobCodeLastUpdated { get; set; }
        /// <summary>
        /// Gets or sets Location Last Updated
        /// </summary>
        public string LocationLastUpdated { get; set; }
        /// <summary>
        /// Gets or sets Name Last Updated
        /// </summary>
        public string NameLastUpdated { get; set; }
        /// <summary>
        /// Gets or sets Work Phone Last Updated
        /// </summary>
        public string WorkPhoneLastUpdated { get; set; }
        /// <summary>
        /// Gets or sets Department Object
        /// </summary>
        public Department Department { get; set; }
    }
    /// <summary>
    /// Defines the full response from the DataHub
    /// </summary>
    public class DataHubResponse
    {
        /// <summary>
        /// Gets or sets Record Count
        /// </summary>
        public Int32 RecordCount { get; set; }
        /// <summary>
        /// Gets or sets Total Record Count
        /// </summary>
        public Int32 TotalRecordCount { get; set; }
        /// <summary>
        /// Gets or sets Has More
        /// </summary>
        public bool HasMore { get; set; }
        /// <summary>
        /// Gets or sets an Array of Employee Objects.
        /// </summary>
        public Employee[] Employees { get; set; }
    }

}
