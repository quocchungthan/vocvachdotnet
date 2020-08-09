using System;
using EasyAppleNotes.ModuleNotes.DataLayer;
using Moq;

namespace AppleEasyNotesTests.DataLayer
{
    public abstract class RepositoryTestsBase
    {

        protected readonly Mock<INotestoreDatabaseSettings> _mockDbSetting;

        public RepositoryTestsBase()
        {
            _mockDbSetting = new Mock<INotestoreDatabaseSettings>();

            _mockDbSetting.SetupGet(x => x.ConnectionString).Returns("mongodb://localhost:27017,localhost:27018,localhost:27019?replicaSet=rs");
            _mockDbSetting.SetupGet(x => x.DatabaseName).Returns("chunbattuTests");
            _mockDbSetting.SetupGet(x => x.CollectionNameNotes).Returns("notes");
            _mockDbSetting.SetupGet(x => x.CollectionNameTags).Returns("tags");

            // CreateDb
            PrepareDb();
        }

        public void Dispose()
        {
            // Drop Db
            DropTempDb();
        }

        protected abstract void DropTempDb();

        protected abstract void PrepareDb();
    }
}
