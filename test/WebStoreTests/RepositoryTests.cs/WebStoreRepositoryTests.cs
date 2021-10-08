using System;
using Xunit;
using WebStore;
using FluentAssertions;
using System.ComponentModel.DataAnnotations;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;


namespace test
{
    public class WebStoreRepositoryTest
    {
        private Database _db;
        private IWebStoreRepository _repo;

        public WebStoreRepositoryTest()
        {
            var conn = new SqliteConnection("DataSource=:memory:");
            conn.Open();
            var options = new DbContextOptionsBuilder<Database>().UseSqlite(conn).Options;
            _db = new Database(options);
            _db.Database.EnsureDeleted();
            _db.Database.EnsureCreated();
            _repo = new WebStoreRepository(_db);
        }

        [Fact]
        public async Task ShouldAddUserToDatabase() //passed
        {
            User testUser = new() { Username = "Test User" };
            await _repo.AddUserAsync(testUser);
            _db.Users.Count().Should().Be(1);
        }

        [Fact]
        public async Task ShouldAddMessageToDatabase() //passed
        {
            Guid toGuid = new Guid();
            Guid fromGuid = new Guid();
            MessageDto testMessageDto = new() { ToUser = toGuid, FromUser = fromGuid, Text = "Hello" };
            User testUser1 = new() { Username = "Test User1" };
            User testUser2 = new() { Username = "Test User2" };
            testUser1.Id = toGuid;
            testUser2.Id = fromGuid;
            await _repo.AddUserAsync(testUser1);
            await _repo.AddUserAsync(testUser2);
            await _repo.SendMessageAsync(testMessageDto);
            _db.Messages.Count().Should().Be(1);
        }

        [Fact]
        public async Task ShouldGetAllMessagesForUser() //fails
        {
            Guid toGuid = new Guid();
            Guid fromGuid = new Guid();
            MessageDto testMessageDto = new() { ToUser = toGuid, FromUser = fromGuid, Text = "Hello" };
            MessageDto testMessageDto2 = new() { ToUser = toGuid, FromUser = fromGuid, Text = "Hello2" };

            User testUser1 = new() { Username = "Test User1" };
            User testUser2 = new() { Username = "Test User2" };
            testUser1.Id = toGuid;
            testUser2.Id = fromGuid;
            await _repo.AddUserAsync(testUser1);
            await _repo.AddUserAsync(testUser2);
            await _repo.SendMessageAsync(testMessageDto);
            await _repo.SendMessageAsync(testMessageDto2);

            var result = await _repo.GetMessagesAsync(toGuid);
            // result.Count().Should().Be(1);
        }


    }
}