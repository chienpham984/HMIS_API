using System;
using HMIS_API.Repository.ModelView;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HMIS_API.Repository.Models
{
    public partial class HMIS_BKKContext : DbContext
    {
        public HMIS_BKKContext()
        {
        }

        public HMIS_BKKContext(DbContextOptions<HMIS_BKKContext> options)
            : base(options)
        {
        }
        public virtual DbSet<SMIS2> SMIS2 { get; set; }
        public virtual DbSet<SMIS1> SMIS { get; set; }
        public virtual DbSet<Acgt> Acgts { get; set; }
        public virtual DbSet<Aegt> Aegts { get; set; }
        public virtual DbSet<Aibt> Aibts { get; set; }
        public virtual DbSet<Aldt> Aldts { get; set; }
        public virtual DbSet<Aobt> Aobts { get; set; }
        public virtual DbSet<ApiFlight> ApiFlights { get; set; }
        public virtual DbSet<UserModeDetail> UserModeDetails { get; set; }
        public virtual DbSet<ApiUser> ApiUsers { get; set; }
        public virtual DbSet<Ardt> Ardts { get; set; }
        public virtual DbSet<Asbt> Asbts { get; set; }
        public virtual DbSet<Belt> Belts { get; set; }
        public virtual DbSet<BoPhan> BoPhans { get; set; }
        public virtual DbSet<ClientAddress> ClientAddresses { get; set; }
        public virtual DbSet<CongViec> CongViecs { get; set; }
        public virtual DbSet<Eibt> Eibts { get; set; }
        public virtual DbSet<Eldt> Eldts { get; set; }
        public virtual DbSet<Eobt> Eobts { get; set; }
        public virtual DbSet<ErrorCategory> ErrorCategories { get; set; }
        public virtual DbSet<ErrorDetail> ErrorDetails { get; set; }
        public virtual DbSet<Etttcategory> Etttcategories { get; set; }
        public virtual DbSet<Etttdetail> Etttdetails { get; set; }
        public virtual DbSet<FacRegNo> FacRegNos { get; set; }
        public virtual DbSet<FacType> FacTypes { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Gate> Gates { get; set; }
        public virtual DbSet<DPOS> DPOSs { get; set; }
        public virtual DbSet<ATOT> ATOTs { get; set; }
        public virtual DbSet<LifeCycle> LifeCycles { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Nature> Natures { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Sibt> Sibts { get; set; }
        public virtual DbSet<Sobt> Sobts { get; set; }
        public virtual DbSet<StatusCategory> StatusCategories { get; set; }
        public virtual DbSet<StatusDetail> StatusDetails { get; set; }
        public virtual DbSet<Std> Stds { get; set; }
        public virtual DbSet<Time> Times { get; set; }
        public virtual DbSet<TimesBkk> TimesBkks { get; set; }
        public virtual DbSet<Tobt> Tobts { get; set; }
        public virtual DbSet<Tsat> Tsats { get; set; }
        public virtual DbSet<UserAreaDetail> UserAreaDetails { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<MailSystem> MailSystems { get; set; }
        public virtual DbSet<UserFunction> UserFunctions { get; set; }
        public virtual DbSet<GroupDocByDept> GroupDocByDepts { get; set; }
        
        public virtual DbSet<FlightUpdate> FlightUpdates { get; set; }
        public virtual DbSet<Ttot> Ttots { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<ViewConfigDefault> ViewConfigDefaults { get; set; }
        public virtual DbSet<ViewConfigDetail> ViewConfigDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=172.16.19.88;Initial Catalog=HMIS_BKK;User ID=hgs;Password=abcd@1234!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Vietnamese_CI_AS");

            modelBuilder.Entity<Acgt>(entity =>
            {
                entity.ToTable("ACGT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Acvstatus).HasColumnName("ACVStatus");

                entity.Property(e => e.Acvtime)
                    .HasColumnType("datetime")
                    .HasColumnName("ACVTime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.FlightDate)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Mgha)
                    .HasMaxLength(5)
                    .HasColumnName("MGHA")
                    .IsFixedLength(true);

                entity.Property(e => e.Time)
                    .HasMaxLength(5)
                    .IsFixedLength(true);
                entity.Property(e => e.FlightId).HasColumnName("FlightId");
                entity.Property(e => e.UserName).HasMaxLength(50);
                entity.Property(e => e.Remark);
            });

            modelBuilder.Entity<Aegt>(entity =>
            {
                entity.ToTable("AEGT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Acvstatus).HasColumnName("ACVStatus");

                entity.Property(e => e.Acvtime)
                    .HasColumnType("datetime")
                    .HasColumnName("ACVTime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Mgha)
                    .HasMaxLength(5)
                    .HasColumnName("MGHA")
                    .IsFixedLength(true);

                entity.Property(e => e.Time)
                    .HasMaxLength(5)
                    .IsFixedLength(true);
                entity.Property(e => e.FlightId).HasColumnName("FlightId");
                entity.Property(e => e.UserName).HasMaxLength(50);
                entity.Property(e => e.Remark);
            });

            modelBuilder.Entity<Aibt>(entity =>
            {
                entity.ToTable("AIBT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Acvstatus).HasColumnName("ACVStatus");

                entity.Property(e => e.Acvtime)
                    .HasColumnType("datetime")
                    .HasColumnName("ACVTime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Mgha)
                    .HasMaxLength(5)
                    .HasColumnName("MGHA")
                    .IsFixedLength(true);

                entity.Property(e => e.Time)
                    .HasMaxLength(5)
                    .IsFixedLength(true);
                entity.Property(e => e.FlightId).HasColumnName("FlightId");
                entity.Property(e => e.UserName).HasMaxLength(50);
                entity.Property(e => e.Remark);
            });

            modelBuilder.Entity<Aldt>(entity =>
            {
                entity.ToTable("ALDT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Mgha)
                    .HasMaxLength(5)
                    .HasColumnName("MGHA")
                    .IsFixedLength(true);

                entity.Property(e => e.Time)
                    .HasMaxLength(5)
                    .IsFixedLength(true);
                entity.Property(e => e.FlightId).HasColumnName("FlightId");
                entity.Property(e => e.TimeReceive).HasColumnType("datetime");
            });

            modelBuilder.Entity<Aobt>(entity =>
            {
                entity.ToTable("AOBT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Acvstatus).HasColumnName("ACVStatus");

                entity.Property(e => e.Acvtime)
                    .HasColumnType("datetime")
                    .HasColumnName("ACVTime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Mgha)
                    .HasMaxLength(5)
                    .HasColumnName("MGHA")
                    .IsFixedLength(true);

                entity.Property(e => e.Time)
                    .HasMaxLength(5)
                    .IsFixedLength(true);
                entity.Property(e => e.FlightId).HasColumnName("FlightId");
                entity.Property(e => e.UserName).HasMaxLength(50);
                entity.Property(e => e.Remark);
            });

            modelBuilder.Entity<ApiFlight>(entity =>
            {
                entity.HasKey(e => e.FlightId);

                entity.ToTable("API_Flight");

                entity.Property(e => e.FlightId)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.AcType)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.Acgt)
                    .HasMaxLength(5)
                    .HasColumnName("ACGT")
                    .IsFixedLength(true);

                entity.Property(e => e.AcregNo)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.Aegt)
                    .HasMaxLength(5)
                    .HasColumnName("AEGT")
                    .IsFixedLength(true);

                entity.Property(e => e.Aibt)
                    .HasMaxLength(5)
                    .HasColumnName("AIBT")
                    .IsFixedLength(true);

                entity.Property(e => e.Aobt)
                    .HasMaxLength(5)
                    .HasColumnName("AOBT")
                    .IsFixedLength(true);

                entity.Property(e => e.Ardt)
                    .HasMaxLength(5)
                    .HasColumnName("ARDT")
                    .IsFixedLength(true);

                entity.Property(e => e.ArrDep)
                    .HasMaxLength(4)
                    .IsFixedLength(true);

                entity.Property(e => e.Asbt)
                    .HasMaxLength(5)
                    .HasColumnName("ASBT")
                    .IsFixedLength(true);

                entity.Property(e => e.Base)
                    .HasMaxLength(5)
                    .IsFixedLength(true);

                entity.Property(e => e.Eobt)
                    .HasMaxLength(5)
                    .HasColumnName("EOBT")
                    .IsFixedLength(true);

                entity.Property(e => e.Ettt).HasColumnName("ETTT");

                entity.Property(e => e.FlightDate).HasColumnType("datetime");

                entity.Property(e => e.FlightNo)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.FlightType)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Mgha)
                    .HasMaxLength(5)
                    .HasColumnName("MGHA")
                    .IsFixedLength(true);

                entity.Property(e => e.Route)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.Sibt)
                    .HasMaxLength(5)
                    .HasColumnName("SIBT")
                    .IsFixedLength(true);

                entity.Property(e => e.Sobt)
                    .HasMaxLength(5)
                    .HasColumnName("SOBT")
                    .IsFixedLength(true);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Tobt)
                    .HasMaxLength(5)
                    .HasColumnName("TOBT")
                    .IsFixedLength(true);

            });

            modelBuilder.Entity<ApiUser>(entity =>
            {
                entity.ToTable("API_User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Pasword)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.UserName).HasMaxLength(20);
            });
            modelBuilder.Entity<UserModeDetail>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.ID);
                entity.Property(e => e.FullName);
                entity.Property(e => e.UserName);
                entity.Property(e => e.Email);
                entity.Property(e => e.PhoneNumber);
                entity.Property(e => e.DeptCode);
                entity.Property(e => e.RoleCode);
                entity.Property(e => e.ListDocument);
                entity.Property(e => e.AreaName);
            });

            modelBuilder.Entity<Ardt>(entity =>
            {
                entity.ToTable("ARDT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Acvstatus).HasColumnName("ACVStatus");

                entity.Property(e => e.Acvtime)
                    .HasColumnType("datetime")
                    .HasColumnName("ACVTime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Mgha)
                    .HasMaxLength(5)
                    .HasColumnName("MGHA")
                    .IsFixedLength(true);

                entity.Property(e => e.Time)
                    .HasMaxLength(5)
                    .IsFixedLength(true);
                entity.Property(e => e.FlightId).HasColumnName("FlightId");
                entity.Property(e => e.UserName).HasMaxLength(50);
                entity.Property(e => e.Remark);
            });

            modelBuilder.Entity<Asbt>(entity =>
            {
                entity.ToTable("ASBT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Acvstatus).HasColumnName("ACVStatus");

                entity.Property(e => e.Acvtime)
                    .HasColumnType("datetime")
                    .HasColumnName("ACVTime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Mgha)
                    .HasMaxLength(5)
                    .HasColumnName("MGHA")
                    .IsFixedLength(true);

                entity.Property(e => e.Time)
                    .HasMaxLength(5)
                    .IsFixedLength(true);

                entity.Property(e => e.UserName).HasMaxLength(50);
                entity.Property(e => e.Remark);
            });

            modelBuilder.Entity<Belt>(entity =>
            {
                entity.ToTable("Belt");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BeltNo)
                    .HasMaxLength(5)
                    .IsFixedLength(true);

                entity.Property(e => e.Mgha)
                    .HasMaxLength(5)
                    .HasColumnName("MGHA")
                    .IsFixedLength(true);
                entity.Property(e => e.FlightId).HasColumnName("FlightId");
                entity.Property(e => e.TimeReceive).HasColumnType("datetime");
            });

            modelBuilder.Entity<BoPhan>(entity =>
            {
                entity.ToTable("BoPhan");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MaBoPhan)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.TenBoPhan).HasMaxLength(500);
            });

            modelBuilder.Entity<ClientAddress>(entity =>
            {
                entity.ToTable("ClientAddress");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.FlightDate)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<CongViec>(entity =>
            {
                entity.ToTable("CongViec");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FlightDate)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.FlightId).HasColumnName("FlightID");

                entity.Property(e => e.IdNguoiDung).HasColumnName("id_NguoiDung");
            });

            modelBuilder.Entity<Eibt>(entity =>
            {
                entity.ToTable("EIBT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Mgha)
                    .HasMaxLength(5)
                    .HasColumnName("MGHA")
                    .IsFixedLength(true);

                entity.Property(e => e.Time)
                    .HasMaxLength(5)
                    .IsFixedLength(true);
                entity.Property(e => e.FlightId).HasColumnName("FlightId");
                entity.Property(e => e.TimeReceive).HasColumnType("datetime");
            });

            modelBuilder.Entity<Eldt>(entity =>
            {
                entity.ToTable("ELDT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Mgha)
                    .HasMaxLength(5)
                    .HasColumnName("MGHA")
                    .IsFixedLength(true);

                entity.Property(e => e.Time)
                    .HasMaxLength(5)
                    .IsFixedLength(true);

                entity.Property(e => e.TimeReceive).HasColumnType("datetime");
            });

            modelBuilder.Entity<Eobt>(entity =>
            {
                entity.ToTable("EOBT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Acvstatus).HasColumnName("ACVStatus");

                entity.Property(e => e.Acvtime)
                    .HasColumnType("datetime")
                    .HasColumnName("ACVTime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.FlightDate)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Time)
                    .HasMaxLength(5)
                    .IsFixedLength(true);
                entity.Property(e => e.FlightId).HasColumnName("FlightId");
                entity.Property(e => e.UserName).HasMaxLength(50);
            });
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.FlightId).HasColumnName("FlightId");
                entity.Property(e => e.Pax).HasColumnName("Pax");
                entity.Property(e => e.MGHA).HasColumnName("MGHA");
            });

            modelBuilder.Entity<ErrorCategory>(entity =>
            {
                entity.ToTable("ErrorCategory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ErrorCode)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Remark).HasMaxLength(200);
            });

            modelBuilder.Entity<ErrorDetail>(entity =>
            {
                entity.ToTable("ErrorDetail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datemodified)
                    .HasColumnType("datetime")
                    .HasColumnName("datemodified");

                entity.Property(e => e.Remark).HasMaxLength(200);

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Etttcategory>(entity =>
            {
                entity.ToTable("ETTTCategory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Airlines)
                    .HasMaxLength(3)
                    .IsFixedLength(true);

                entity.Property(e => e.FlightType)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Nature)
                    .HasMaxLength(2)
                    .IsFixedLength(true);

                entity.Property(e => e.NatureOfFlight)
                    .HasMaxLength(3)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Etttdetail>(entity =>
            {
                entity.ToTable("ETTTDetails");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Acvstatus).HasColumnName("ACVStatus");

                entity.Property(e => e.Acvtime)
                    .HasColumnType("datetime")
                    .HasColumnName("ACVTime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<FacRegNo>(entity =>
            {
                entity.ToTable("FAcRegNo");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AcRegNo)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.Acvstatus).HasColumnName("ACVStatus");

                entity.Property(e => e.Acvtime)
                    .HasColumnType("datetime")
                    .HasColumnName("ACVTime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<FacType>(entity =>
            {
                entity.ToTable("FAcType");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AcType)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.Acvstatus).HasColumnName("ACVStatus");

                entity.Property(e => e.Acvtime)
                    .HasColumnType("datetime")
                    .HasColumnName("ACVTime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable("Flight");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FAcgt)
                    .HasMaxLength(5)
                    .HasColumnName("FACGT")
                    .IsFixedLength(true);

                entity.Property(e => e.FAibt)
                    .HasMaxLength(5)
                    .HasColumnName("FAIBT")
                    .IsFixedLength(true);

                entity.Property(e => e.FAldt)
                    .HasMaxLength(5)
                    .HasColumnName("FALDT")
                    .IsFixedLength(true);

                entity.Property(e => e.FAobt)
                    .HasMaxLength(5)
                    .HasColumnName("FAOBT")
                    .IsFixedLength(true);

                entity.Property(e => e.Apark)
                    .HasMaxLength(5)
                    .IsFixedLength(true);

                entity.Property(e => e.FArdt)
                    .HasMaxLength(5)
                    .HasColumnName("FARDT")
                    .IsFixedLength(true);

                entity.Property(e => e.ArrDep)
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.Property(e => e.FAsbt)
                    .HasMaxLength(5)
                    .HasColumnName("FASBT")
                    .IsFixedLength(true);

                entity.Property(e => e.FBelt)
                    .HasMaxLength(5)
                      .HasColumnName("FBelt")
                    .IsFixedLength(true);

                entity.Property(e => e.Dpark)
                    .HasMaxLength(5)
                    .IsFixedLength(true);

                entity.Property(e => e.FEibt)
                    .HasMaxLength(5)
                    .HasColumnName("FEIBT")
                    .IsFixedLength(true);

                entity.Property(e => e.FEldt)
                    .HasMaxLength(5)
                    .HasColumnName("FELDT")
                    .IsFixedLength(true);

                entity.Property(e => e.FEobt)
                    .HasMaxLength(5)
                    .HasColumnName("FEOBT")
                    .IsFixedLength(true);

                entity.Property(e => e.Ettt).HasColumnName("ETTT");

                entity.Property(e => e.FlightDate)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.FlightDateTime).HasColumnType("datetime");

                entity.Property(e => e.FlightNo)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.FlightTime)
                    .HasMaxLength(5)
                    .IsFixedLength(true);

                entity.Property(e => e.Nature)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.RouteFlight)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.FSibt)
                    .HasMaxLength(5)
                    .HasColumnName("FSIBT")
                    .IsFixedLength(true);

                entity.Property(e => e.FSobt)
                    .HasMaxLength(5)
                    .HasColumnName("FSOBT")
                    .IsFixedLength(true);

                entity.Property(e => e.Status)
                    .HasMaxLength(5)
                    .IsFixedLength(true);

                entity.Property(e => e.FTobt)
                    .HasMaxLength(5)
                    .HasColumnName("FTOBT")
                    .IsFixedLength(true);

                entity.Property(e => e.FTsat)
                    .HasMaxLength(5)
                    .HasColumnName("FTSAT")
                    .IsFixedLength(true);

                entity.Property(e => e.FTtot)
                    .HasMaxLength(5)
                    .HasColumnName("FTTOT")
                    .IsFixedLength(true);
                entity.Property(e => e.FATOT);
                entity.Property(e => e.Dgate);
                entity.Property(e => e.FAEGT);
                entity.Property(e => e.MVT);
                entity.Property(e => e.CLSD);
            });

            modelBuilder.Entity<Gate>(entity =>
            {
                entity.ToTable("Gate");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dpark)
                    .HasMaxLength(5)
                    .IsFixedLength(true);

                entity.Property(e => e.Mgha)
                    .HasMaxLength(5)
                    .HasColumnName("MGHA")
                    .IsFixedLength(true);
                entity.Property(e => e.FlightId).HasColumnName("FlightId");
                entity.Property(e => e.TimeReceive).HasColumnType("datetime");
            });
            modelBuilder.Entity<ATOT>(entity =>
            {
                entity.ToTable("ATOT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Time)
                    .HasMaxLength(5)
                    .IsFixedLength(true).HasColumnName("Time");

                entity.Property(e => e.Mgha)
                    .HasMaxLength(5)
                    .HasColumnName("MGHA")
                    .IsFixedLength(true);
                entity.Property(e => e.FlightId).HasColumnName("FlightId");

                entity.Property(e => e.TimeReceive).HasColumnName("TimeReceive").HasColumnType("datetime");
            });

            modelBuilder.Entity<DPOS>(entity =>
            {
                entity.ToTable("DPOS");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dposition)
                    .HasMaxLength(5)
                    .IsFixedLength(true);

                entity.Property(e => e.Mgha)
                    .HasMaxLength(5)
                    .HasColumnName("MGHA")
                    .IsFixedLength(true);
                entity.Property(e => e.FlightId).HasColumnName("FlightId");
                entity.Property(e => e.TimeReceive).HasColumnType("datetime");
            });

            modelBuilder.Entity<LifeCycle>(entity =>
            {
                entity.ToTable("LifeCycle");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Mgha)
                    .HasMaxLength(5)
                    .HasColumnName("MGHA")
                    .IsFixedLength(true);

                entity.Property(e => e.Status)
                    .HasMaxLength(3)
                    .IsFixedLength(true);

                entity.Property(e => e.TimeReceive).HasColumnType("datetime");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.MessageId).HasColumnName("MessageID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.EmptyMessage).HasMaxLength(50);

                entity.Property(e => e.Message1)
                    .HasMaxLength(50)
                    .HasColumnName("Message");
            });

            modelBuilder.Entity<Nature>(entity =>
            {
                entity.ToTable("Nature");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Acvstatus).HasColumnName("ACVStatus");

                entity.Property(e => e.Acvtime)
                    .HasColumnType("datetime")
                    .HasColumnName("ACVTime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.FlightType)
                    .HasMaxLength(3)
                    .IsFixedLength(true);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.ToTable("NguoiDung");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(200);

                entity.Property(e => e.IdBoPhan).HasColumnName("id_BoPhan");

                entity.Property(e => e.PassWord).HasMaxLength(20);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(50)
                    .HasColumnName("sdt");

                entity.Property(e => e.Url).HasMaxLength(200);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("Notification");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.FieldName)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Mgha)
                    .HasMaxLength(5)
                    .HasColumnName("MGHA")
                    .IsFixedLength(true);

                entity.Property(e => e.NewValue)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.OldValue)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apark)
                    .HasMaxLength(5)
                    .IsFixedLength(true);

                entity.Property(e => e.Mgha)
                    .HasMaxLength(5)
                    .HasColumnName("MGHA")
                    .IsFixedLength(true);

                entity.Property(e => e.TimeReceive).HasColumnType("datetime");
            });

            modelBuilder.Entity<Sibt>(entity =>
            {
                entity.ToTable("SIBT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Acvstatus).HasColumnName("ACVStatus");

                entity.Property(e => e.Acvtime)
                    .HasColumnType("datetime")
                    .HasColumnName("ACVTime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.FlightDate)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Time)
                    .HasMaxLength(5)
                    .IsFixedLength(true);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<Sobt>(entity =>
            {
                entity.ToTable("SOBT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Acvstatus).HasColumnName("ACVStatus");

                entity.Property(e => e.Acvtime)
                    .HasColumnType("datetime")
                    .HasColumnName("ACVTime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.FlightDate)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Time)
                    .HasMaxLength(5)
                    .IsFixedLength(true);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<StatusCategory>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.ToTable("StatusCategory");

                entity.Property(e => e.Remark).HasMaxLength(50);

                entity.Property(e => e.StatusName)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<StatusDetail>(entity =>
            {
                entity.ToTable("StatusDetail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Acvstatus).HasColumnName("ACVStatus");

                entity.Property(e => e.Acvtime)
                    .HasColumnType("datetime")
                    .HasColumnName("ACVTime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Mgha)
                    .HasMaxLength(5)
                    .HasColumnName("MGHA")
                    .IsFixedLength(true);

                entity.Property(e => e.StatusName)
                    .HasMaxLength(5)
                    .IsFixedLength(true);

                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<Std>(entity =>
            {
                entity.ToTable("STD");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.FlightDate)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Time)
                    .HasMaxLength(5)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Time>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FlightDate)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.IsSent).HasColumnName("isSent");

                entity.Property(e => e.TimeSent)
                    .HasColumnType("datetime")
                    .HasColumnName("timeSent");

                entity.Property(e => e.Timechange)
                    .HasMaxLength(22)
                    .HasColumnName("timechange")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TimesBkk>(entity =>
            {
                entity.ToTable("Times_BKK");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FlightDate)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.IsSent).HasColumnName("isSent");

                entity.Property(e => e.TimeSent)
                    .HasColumnType("datetime")
                    .HasColumnName("timeSent");

                entity.Property(e => e.Timechange)
                    .HasMaxLength(22)
                    .HasColumnName("timechange")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Tobt>(entity =>
            {
                entity.ToTable("TOBT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Acvstatus).HasColumnName("ACVStatus");

                entity.Property(e => e.Acvtime)
                    .HasColumnType("datetime")
                    .HasColumnName("ACVTime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.Mgha)
                    .HasMaxLength(5)
                    .HasColumnName("MGHA")
                    .IsFixedLength(true);

                entity.Property(e => e.Time)
                    .HasMaxLength(5)
                    .IsFixedLength(true);
                entity.Property(e => e.FlightId).HasColumnName("FlightId");
                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            modelBuilder.Entity<Tsat>(entity =>
            {
                entity.ToTable("TSAT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Mgha)
                    .HasMaxLength(5)
                    .HasColumnName("MGHA")
                    .IsFixedLength(true);

                entity.Property(e => e.Time)
                    .HasMaxLength(5)
                    .IsFixedLength(true);
                entity.Property(e => e.FlightId).HasColumnName("FlightId");
                entity.Property(e => e.TimeReceive).HasColumnType("datetime");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.DeptName).HasColumnName("DeptName");
                entity.Property(e => e.DeptCode).HasColumnName("DeptCode");
            });

            modelBuilder.Entity<MailSystem>(entity =>
            {
                entity.ToTable("MailSystem");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.MailName).HasColumnName("MailName");
                entity.Property(e => e.PassWord).HasColumnName("PassWord");
            });
            modelBuilder.Entity<GroupDocByDept>(entity =>
            {
                entity.ToTable("GroupDocByDept");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.DeptId).HasColumnName("DeptId");
                entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeId");
            });
            
            modelBuilder.Entity<UserFunction>(entity =>
            {
                entity.ToTable("UserFunction");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.UserId).HasColumnName("UserId");
                entity.Property(e => e.ListView).HasColumnName("ListView");
                entity.Property(e => e.ListInsert).HasColumnName("ListInsert");
                entity.Property(e => e.ListUpdate).HasColumnName("ListUpdate");
            });
            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.RoleName).HasColumnName("RoleName");
                entity.Property(e => e.RoleCode).HasColumnName("RoleCode");
            });
            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("Document");
                entity.Property(e => e.DocumentId).HasColumnName("DocumentId");
                entity.Property(e => e.FlightID).HasColumnName("FlightID");
                entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeId");
                entity.Property(e => e.DocumentName).HasColumnName("DocumentName");
                entity.Property(e => e.DateModified).HasColumnName("DateModified");
                entity.Property(e => e.DocumentSize).HasColumnName("DocumentSize");
                entity.Property(e => e.FullPath).HasColumnName("FullPath");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.ToTable("DocumentType");
                entity.Property(e => e.DocumentTypeId).HasColumnName("DocumentTypeId");
                entity.Property(e => e.DocumentTypeName).HasColumnName("DocumentTypeName");
                entity.Property(e => e.stt).HasColumnName("stt");

            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.FullName).HasColumnName("FullName");
                entity.Property(e => e.DOB).HasColumnName("DOB");
                entity.Property(e => e.UserName).HasColumnType("UserName");
                entity.Property(e => e.PassWord).HasColumnName("PassWord");
                entity.Property(e => e.Email).HasColumnName("Email");
                entity.Property(e => e.PhoneNumber).HasColumnName("PhoneNumber");
                entity.Property(e => e.DeptId).HasColumnType("DeptId");
                entity.Property(e => e.RolesId).HasColumnName("RolesId");
                entity.Property(e => e.ListStation).HasColumnName("ListStation");
                entity.Property(e => e.UserStatus).HasColumnType("UserStatus");
            });

            modelBuilder.Entity<FlightUpdate>(entity =>
            {
                entity.HasKey(e => e.FlightID);
                entity.ToTable("FlightUpdate");
                entity.Property(e => e.FlightID).HasColumnName("FlightID");
                entity.Property(e => e.FlightNo).HasColumnName("FlightNo");
                entity.Property(e => e.LinkFlight).HasColumnName("LinkFlight");
                entity.Property(e => e.ArrDep).HasColumnType("ArrDep");
                entity.Property(e => e.FlightDate).HasColumnName("FlightDate");
                entity.Property(e => e.FlightTime).HasColumnName("FlightTime");
                entity.Property(e => e.ArrTime).HasColumnName("ArrTime");
                entity.Property(e => e.DepTime).HasColumnType("DepTime");
                entity.Property(e => e.RouteFlight).HasColumnName("RouteFlight");
                entity.Property(e => e.AcRegNo).HasColumnName("AcRegNo");
                entity.Property(e => e.AcType).HasColumnType("AcType");
                entity.Property(e => e.Nature).HasColumnName("Nature");
                entity.Property(e => e.Position).HasColumnType("Position");
                entity.Property(e => e.StatusFlight).HasColumnName("StatusFlight");
                entity.Property(e => e.Gate).HasColumnName("Gate");
                entity.Property(e => e.Note).HasColumnType("Note");
                entity.Property(e => e.UserName).HasColumnName("UserName");
                entity.Property(e => e.DateModified).HasColumnName("DateModified");
                entity.Property(e => e.FlightDateTime).HasColumnType("FlightDateTime");

            });

            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("Area");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.AreaName).HasColumnType("AreaName");
            });
            modelBuilder.Entity<UserAreaDetail>(entity =>
            {
                entity.ToTable("UserAreaDetail");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.UserId).HasColumnType("UserId");
                entity.Property(e => e.AreaId).HasColumnType("AreaId");
            });

            modelBuilder.Entity<Ttot>(entity =>
            {
                entity.ToTable("TTOT");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Mgha)
                    .HasMaxLength(5)
                    .HasColumnName("MGHA")
                    .IsFixedLength(true);

                entity.Property(e => e.Time)
                    .HasMaxLength(5)
                    .IsFixedLength(true);
                entity.Property(e => e.FlightId).HasColumnName("FlightId");
                entity.Property(e => e.TimeReceive).HasColumnType("datetime");
            });

            modelBuilder.Entity<ViewConfigDefault>(entity =>
            {
                entity.ToTable("ViewConfigDefault");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdBoPhan).HasColumnName("id_BoPhan");

                entity.Property(e => e.ListColumn).HasMaxLength(200);
            });

            modelBuilder.Entity<ViewConfigDetail>(entity =>
            {
                entity.ToTable("ViewConfigDetail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdBoPhan).HasColumnName("id_BoPhan");

                entity.Property(e => e.IdNguoiDung).HasColumnName("id_NguoiDung");

                entity.Property(e => e.ListColumn).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
