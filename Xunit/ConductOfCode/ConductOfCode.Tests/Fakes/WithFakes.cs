using System;
using System.Linq.Expressions;
using Moq;
using Moq.AutoMock;

namespace ConductOfCode.Tests.Fakes
{
    /// <summary>
    /// Base class that adds auto mocking/faking to Xunit.
    /// </summary>
    public abstract class WithFakes : IDisposable
    {
        private readonly AutoMocker _mocker;

        private object _subject;

        protected WithFakes()
        {
            _mocker = new AutoMocker();
        }

        public void Dispose()
        {
            _subject = null;
        }

        /// <summary>
        /// Gives access to the subject under specification.
        /// On first access the spec tries to create an instance of the subject type by itself.
        /// </summary>
        /// <typeparam name="TSubject">The type of subject to create.</typeparam>
        /// <returns>The subject of the specification.</returns>
        protected TSubject Subject<TSubject>() where TSubject : class
        {
            if (_subject != null) return _subject as TSubject;

            _subject = _mocker.CreateInstance<TSubject>();

            return (TSubject)_subject;
        }

        /// <summary>
        /// Creates a fake of the type specified by <typeparamref name="TInterfaceType" />.
        /// This method reuses existing instances. If an instance of <typeparamref name="TInterfaceType" />
        /// was already requested it's returned here. (You can say this is kind of a singleton behavior)
        /// Besides that, you can obtain a reference to injected instances/fakes with this method.
        /// </summary>
        /// <typeparam name="TInterfaceType">The type to create a fake for. (Should be an interface or an abstract class)</typeparam>
        /// <returns>
        /// An instance implementing <typeparamref name="TInterfaceType" />.
        /// </returns>
        protected Mock<TInterfaceType> The<TInterfaceType>() where TInterfaceType : class
        {
            return _mocker.GetMock<TInterfaceType>();
        }

        /// <summary>
        /// Configures the specification to use the specified instance for <typeparamref name="TInterfaceType" />.
        /// </summary>
        /// <typeparam name="TInterfaceType">The type to inject.</typeparam>
        /// <param name="instance">The instance to inject.</param>
        protected void With<TInterfaceType>(TInterfaceType instance)
        {
            _mocker.Use(instance);
        }

        /// <summary>
        /// Configures the specification to use the specified mock for <typeparamref name="TInterfaceType" />.
        /// </summary>
        /// <typeparam name="TInterfaceType">The type to inject.</typeparam>
        /// <param name="mock">The mock to inject.</param>
        protected void With<TInterfaceType>(Mock<TInterfaceType> mock) where TInterfaceType : class
        {
            _mocker.Use(mock);
        }

        /// <summary>
        /// Configures the specification to setup a mock with specified behavior for <typeparamref name="TInterfaceType" />.
        /// </summary>
        /// <typeparam name="TInterfaceType">The type to inject.</typeparam>
        /// <param name="setup">The behavior to inject.</param>
        protected void With<TInterfaceType>(Expression<Func<TInterfaceType, bool>> setup) where TInterfaceType : class
        {
            _mocker.Use(setup);
        }
    }
}