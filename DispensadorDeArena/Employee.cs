namespace DispensadorDeArena
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Clock { get; set; }

        [StringLength(102)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Last { get; set; }

        [StringLength(50)]
        public string First { get; set; }

        [StringLength(3)]
        public string HomeDept { get; set; }

        [StringLength(30)]
        public string BadgePin { get; set; }

        public short? JobCode { get; set; }

        public short StatusCode { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? StatusDate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? DateOfBirth { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? DateOfHire { get; set; }

        [StringLength(1)]
        public string Salaried { get; set; }

        public short? OTJobCode { get; set; }

        [Required]
        [StringLength(1)]
        public string Plant { get; set; }

        public byte Shift { get; set; }

        [StringLength(120)]
        public string Password { get; set; }

        public bool? ClockedIn { get; set; }

        public bool? ClockInRequired { get; set; }

        [StringLength(1)]
        public string CommentPending { get; set; }

        public int? QualityGrouping { get; set; }

        [StringLength(50)]
        public string EmailAddress { get; set; }

        public byte? TimeSchedule { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? EndUserLastRead { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? PWLastChanged { get; set; }

        public byte? GraceLoginsLeft { get; set; }

        [StringLength(50)]
        public string WinLogin { get; set; }

        public bool? NoPasswordExpire { get; set; }

        [StringLength(30)]
        public string NetworkName { get; set; }

        public bool? NetworkIsEnabled { get; set; }

        public int? LastChangeClock { get; set; }

        [StringLength(200)]
        public string DutyorFunction { get; set; }

        public short? VacationHours { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? PlanExpireDate { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public bool AutoLabor { get; set; }

        public bool LaborLunchRequired { get; set; }

        public bool GuestRegisrationAltEscort { get; set; }

        [StringLength(3)]
        public string PlantID { get; set; }

        public bool? NoAQCSLogin { get; set; }

        public DateTime? LastSuccessfulLogin { get; set; }
    }
}
