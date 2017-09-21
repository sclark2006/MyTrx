using TestStack.BDDfy;
using Xunit;
using MyTrx.BusinessLogic.Services;
using Moq;
using Shouldly;
using MyTrx.Data.Repositories;
using MyTrx.BusinessLogic.Models;
using MyTrx.Data.Entities;

namespace MyTrx.Test
{

    [Story(
        AsA = "As a User",
        IWant = "I want to use an Id",
        SoThat = "So that I can get an specific transaction")]
    public class TransactionsQueryServiceTest
    {
        private ITransactionsQueryService _transaction_query_service;
        private IRepository _repository;
        private int transaction_id;
        private TransactionModel result;

        [Given]
        void An_existing_transaction_Id()
        {
            transaction_id = 1;
            var mocked_repository = new Mock<IRepository>();
            mocked_repository.Setup(x => x.GetById<Transaction>(transaction_id)).Returns(new Transaction { Id = transaction_id});
            _repository = mocked_repository.Object;

            _transaction_query_service = new TransactionsQueryService(_repository);
        }

        [When]
        void The_User_Searches_a_Transaction()
        {
            result = _transaction_query_service.GetById(transaction_id);
        }

        [Then]
        void It_should_return_a_Transaction()
        {
            result.ShouldNotBeNull();
        }
        [Then]
        void It_should_have_the_specified_Id()
        {
            result.Id.ShouldBe(transaction_id);
        }

        [Fact]
        public void When_searching_for_a_transaction_by_Id()
        {
            this.Given(s => An_existing_transaction_Id(), "An existing transaction Id")
                .When(s => The_User_Searches_a_Transaction(), "the User Searches a Transaction")
                .Then(s => It_should_return_a_Transaction(), "it should return a Transaction")
                .And(s => It_should_have_the_specified_Id(), "and should have the specified Id")

                .BDDfy();
        }

    }
}
