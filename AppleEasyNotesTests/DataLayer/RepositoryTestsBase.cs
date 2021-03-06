﻿using System;
using System.Threading.Tasks;
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

            
        }

        public async Task InitializeAsync()
        {
            await PrepareDb();
        }

        public async Task DisposeAsync()
        {
             await DropTempDb();
        }

        protected abstract Task DropTempDb();

        protected abstract Task PrepareDb();
    }
}
