using System;
using System.Collections.Generic;
using FluentAssertions;
using PrimeService.Exception;
using PrimeService.Service;
using Xunit;

namespace FluentAssertionDemo.Test
{
    public class ExceptionThrowerShould
    {
        private readonly ExceptionThrower _exceptionThrower;

        public ExceptionThrowerShould()
        {
            _exceptionThrower = new ExceptionThrower();
        }

        [Fact]
        public void Throw_Game_Exception()
        {
            Action act = _exceptionThrower.Throw;

            act.Should().Throw<GameException>();
        }

        [Fact]
        public void Throw_Game_Exception_With_Inner_Exception()
        {
            Action act = _exceptionThrower.Throw;

            act.Should().Throw<GameException>().WithInnerException<NotImplementedException>();
        }

        [Fact]
        public void Throw_Game_Exception_With_Proper_Generic_Exception_Message()
        {
            Action act = _exceptionThrower.Throw;

            act.Should().Throw<GameException>().Where(x => x.Message.Contains("Angry bird"));
        }

        [Fact]
        public void Not_Throw_Legacy_Game_Exception()
        {
            Action act = _exceptionThrower.Throw;

            act.Should().NotThrow<GameExceptionLegacy>();
        }

        [Fact]
        public void Throw_Game_Exception_During_Enumeration_On_7()
        {
            Func<IEnumerable<int>> act = _exceptionThrower.ThrowExceptionOn_7;

            act.Should().ThrowExactly<GameException>();
        }

        [Fact]
        public void Throw_Game_Exception_During_Yielding_On_Integer_7()
        {
            Func<IEnumerable<int>> act = _exceptionThrower.ThrowExceptionOn_7_During_Yielding;

            act.Enumerating().Should().ThrowExactly<GameException>();
        }
    }
}
