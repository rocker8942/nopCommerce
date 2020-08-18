using System.Linq;
using FluentMigrator;
using Nop.Core.Domain.Logging;

namespace Nop.Data.Migrations.UpgradeTo440
{
    [NopMigration("2020-06-10 00:00:00", "4.40.0", UpdateMigrationType.Data)]
    [SkipMigrationOnInstall]
    public class DataMigration : MigrationBase
    {
        #region Fields

        private readonly INopDataProvider _dataProvider;

        #endregion

        #region Ctor

        public DataMigration(INopDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        #endregion

        /// <summary>
        /// Collect the UP migration expressions
        /// </summary>
        public override void Up()
        {
            if (!_dataProvider.GetTable<ActivityLogType>().Any(alt => string.Compare(alt.SystemKeyword, "AddNewSpecAttributeGroup", true) == 0))
            {
                _dataProvider.InsertEntity(
                    new ActivityLogType
                    {
                        SystemKeyword = "AddNewSpecAttributeGroup",
                        Enabled = true,
                        Name = "Add a new specification attribute group"
                    }
                );
            }

            if (!_dataProvider.GetTable<ActivityLogType>().Any(alt => string.Compare(alt.SystemKeyword, "EditSpecAttributeGroup", true) == 0))
            {
                _dataProvider.InsertEntity(
                    new ActivityLogType
                    {
                        SystemKeyword = "EditSpecAttributeGroup",
                        Enabled = true,
                        Name = "Edit a specification attribute group"
                    }
                );
            }

            if (!_dataProvider.GetTable<ActivityLogType>().Any(alt => string.Compare(alt.SystemKeyword, "DeleteSpecAttributeGroup", true) == 0))
            {
                _dataProvider.InsertEntity(
                    new ActivityLogType
                    {
                        SystemKeyword = "DeleteSpecAttributeGroup",
                        Enabled = true,
                        Name = "Delete a specification attribute group"
                    }
                );
            }
        }

        public override void Down()
        {
            //add the downgrade logic if necessary 
        }
    }
}
