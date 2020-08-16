using Ioc.Container.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ioc.Container.Abstract
{
    public interface IContainer
    {

        IoCContainer For<TObject>();
        IoCContainer Apply<TContract>();

        void Build();

        T Resolve<T>();
    }
}
