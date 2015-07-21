﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eLearning.Entities;
using eLearning.Mappers;

namespace eLearning.Context
{
    public class LearningContext : DbContext
    {
        public LearningContext() :
            base("eLearningConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LearningContext, LearningContextMigrationConfiguration>());
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Tutor> Tutors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentMapper());
            modelBuilder.Configurations.Add(new SubjectMapper());
            modelBuilder.Configurations.Add(new TutorMapper());
            modelBuilder.Configurations.Add(new CourseMapper());
            modelBuilder.Configurations.Add(new EnrollmentMapper());

            base.OnModelCreating(modelBuilder);
        }
    }
}
