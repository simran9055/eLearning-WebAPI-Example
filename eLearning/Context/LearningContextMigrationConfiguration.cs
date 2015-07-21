﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;

namespace eLearning.Context
{
    class LearningContextMigrationConfiguration : DbMigrationsConfiguration<LearningContext>
    {
        public LearningContextMigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;

        }

#if DEBUG
        protected override void Seed(LearningContext context)
        {
            new LearningDataSeeder(context).Seed();
        }
#endif

    }
}
