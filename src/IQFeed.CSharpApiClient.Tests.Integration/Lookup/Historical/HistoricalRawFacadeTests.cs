﻿using System;
using System.Threading.Tasks;
using IQFeed.CSharpApiClient.Lookup;
using NUnit.Framework;

namespace IQFeed.CSharpApiClient.Tests.Integration.Lookup.Historical
{
    public class HistoricalRawFacadeTests
    {
        private const int TimeoutMs = 30000;
        private const int Datapoints = 100;
        private const string Symbol = "AAPL";

        private LookupClient _lookupClient;

        public HistoricalRawFacadeTests()
        {
            IQFeedLauncher.Start();
        }

        [SetUp]
        public void SetUp()
        {
            _lookupClient = LookupClientFactory.CreateNew();
            _lookupClient.Connect();
        }

        [TearDown]
        public void TearDown()
        {
            _lookupClient.Disconnect();
        }

        [Test, Timeout(TimeoutMs)]
        public async Task Should_Return_String_When_ReqHistoryTickDatapointsAsync()
        {
            var rawTickMessage = await _lookupClient.Historical.Raw.ReqHistoryTickDatapointsAsync(Symbol, Datapoints);
            Assert.IsNotEmpty(rawTickMessage);
        }

        [Test, Timeout(TimeoutMs)]
        public async Task Should_Return_String_When_ReqHistoryTickDaysAsync()
        {
            var rawTickMessage = await _lookupClient.Historical.Raw.ReqHistoryTickDaysAsync(Symbol, int.MaxValue, Datapoints);
            Assert.IsNotEmpty(rawTickMessage);
        }

        [Test, Timeout(TimeoutMs)]
        public async Task Should_Return_String_When_ReqHistoryTickTimeframeAsync()
        {
            var rawTickMessage = await _lookupClient.Historical.Raw.ReqHistoryTickTimeframeAsync(Symbol, null, DateTime.Now.Date, Datapoints);
            Assert.IsNotEmpty(rawTickMessage);
        }

        [Test, Timeout(TimeoutMs)]
        public async Task Should_Return_String_When_ReqHistoryIntervalDatapointsAsync()
        {
            var rawIntervalMessage = await _lookupClient.Historical.Raw.ReqHistoryIntervalDatapointsAsync(Symbol, 5, Datapoints);
            Assert.IsNotEmpty(rawIntervalMessage);
        }

        [Test, Timeout(TimeoutMs)]
        public async Task Should_Return_String_When_ReqHistoryIntervalDaysAsync()
        {
            var rawIntervalMessage = await _lookupClient.Historical.Raw.ReqHistoryIntervalDaysAsync(Symbol, 5, int.MaxValue, Datapoints);
            Assert.IsNotEmpty(rawIntervalMessage);
        }

        [Test, Timeout(TimeoutMs)]
        public async Task Should_Return_String_When_ReqHistoryIntervalTimeframeAsync()
        {
            var rawIntervalMessage = await _lookupClient.Historical.Raw.ReqHistoryIntervalTimeframeAsync(Symbol, 5, null, DateTime.Now.Date);
            Assert.IsNotEmpty(rawIntervalMessage);
        }

        [Test, Timeout(TimeoutMs)]
        public async Task Should_Return_String_When_ReqHistoryDailyDatapointsAsync()
        {
            var rawDailyWeeklyMonthlyMessage = await _lookupClient.Historical.Raw.ReqHistoryDailyDatapointsAsync(Symbol, Datapoints);
            Assert.IsNotEmpty(rawDailyWeeklyMonthlyMessage);
        }

        [Test, Timeout(TimeoutMs)]
        public async Task Should_Return_String_When_ReqHistoryDailyTimeframeAsync()
        {
            var rawDailyWeeklyMonthlyMessage = await _lookupClient.Historical.Raw.ReqHistoryDailyTimeframeAsync(Symbol, null, DateTime.Today.Date);
            Assert.IsNotEmpty(rawDailyWeeklyMonthlyMessage);
        }

        [Test, Timeout(TimeoutMs)]
        public async Task Should_Return_String_When_ReqHistoryWeeklyDatapointsAsync()
        {
            var rawDailyWeeklyMonthlyMessage = await _lookupClient.Historical.Raw.ReqHistoryWeeklyDatapointsAsync(Symbol, Datapoints);
            Assert.IsNotEmpty(rawDailyWeeklyMonthlyMessage);
        }

        [Test, Timeout(TimeoutMs)]
        public async Task Should_Return_String_When_ReqHistoryMonthlyDatapointsAsync()
        {
            var rawDailyWeeklyMonthlyMessage = await _lookupClient.Historical.Raw.ReqHistoryMonthlyDatapointsAsync(Symbol, Datapoints);
            Assert.IsNotEmpty(rawDailyWeeklyMonthlyMessage);
        }

        [Test, Timeout(TimeoutMs)]
        public void Should_Throw_Exception_When_Historical_Getting_Error()
        {
            var ex = Assert.ThrowsAsync<Exception>(async () => await _lookupClient.Historical.Raw.ReqHistoryTickDatapointsAsync("INVALID_SYMBOL_NAME", Datapoints));
        }
    }
}