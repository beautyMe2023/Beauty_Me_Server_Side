//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BeautyMe
{
    using System;
    using System.Collections.Generic;
    
    public partial class Client
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client()
        {
            this.Future_Appointment = new HashSet<Future_Appointment>();
            this.Future_Appointment1 = new HashSet<Future_Appointment>();
            this.Review_Business = new HashSet<Review_Business>();
            this.Review_Client = new HashSet<Review_Client>();
        }
    
        public string ID_number { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public System.DateTime birth_date { get; set; }
        public string gender { get; set; }
        public string phone { get; set; }
        public string Email { get; set; }
        public string AddressStreet { get; set; }
        public string AddressHouseNumber { get; set; }
        public string AddressCity { get; set; }
        public string password { get; set; }
        public string Facebook_link { get; set; }
        public string Instagram_link { get; set; }
        public byte[] Image { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Future_Appointment> Future_Appointment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Future_Appointment> Future_Appointment1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review_Business> Review_Business { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review_Client> Review_Client { get; set; }
    }
}