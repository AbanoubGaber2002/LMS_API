using Microsoft.EntityFrameworkCore;

namespace firstAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
       /* public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<QuizResult> QuizResults { get; set; }
        public DbSet<Submission> Submissions { get; set; }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
    .HasKey(e => e.CourseID);

            modelBuilder.Entity<User>()
         .Property(u => u.UserID)
         .ValueGeneratedOnAdd(); // Ensures UserID is an identity column

            /* modelBuilder.Entity<Submission>()
     .HasKey(e => e.SubmissionID);

             modelBuilder.Entity<Assignment>()
     .HasKey(e => e.AssignmentID);

             // Configure the primary key for Quizzes
             modelBuilder.Entity<Quiz>()
                 .HasKey(e => e.QuizID);

             // Configure the primary key for QuizResults
             modelBuilder.Entity<QuizResult>()
                 .HasKey(q => q.QuizResultID);*/

            // Configure the primary key for Enrollments
            // Configure Enrollment primary key and identity column
            modelBuilder.Entity<Enrollment>()
                .Property(e => e.EnrollmentID)
                .ValueGeneratedOnAdd();

            // Configure relationships
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.User) // Single user
                .WithMany(u => u.Enrollments) // Multiple enrollments
                .HasForeignKey(e => e.UserID);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course) // Single course
                .WithMany(c => c.Enrollments) // Multiple enrollments
                .HasForeignKey(e => e.CourseID);

            // Add additional configurations as needed
            base.OnModelCreating(modelBuilder);

        }
    }
}
