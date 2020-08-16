using Ioc.Container.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ioc.Container.Concrete
{
    public class IoCContainer:IContainer
    {
        private IoCContainer _ioCContainer;

        Dictionary<string, object> _ioCContainerDictionary = new Dictionary<string, object>();

        private List<Type> _TObject = new List<Type>();

        private List<Type> _TContract= new List<Type>();

        public IoCContainer()
        {
            _ioCContainer = this;
        }

        public IoCContainer For<TObject>()
        {
            _ioCContainer._TObject.Add(typeof(TObject));
            return this;
        }
        public IoCContainer Apply<TContract>()
        {
            _ioCContainer._TContract.Add(typeof(TContract));
            return this;
        }


        public void Build()
        {
            try
            {
                foreach (var item  in _TContract)
                {
                    var isThereObjİnstance = CheckObjRef(item.Name);
                    if (!isThereObjİnstance)
                    {
                        int index = _TContract.IndexOf(item);
                        var key = item.Name;
                        var value = Activator.CreateInstance(_TObject[index]);
                        _ioCContainerDictionary.Add(key,value);
                    }
                }
             
            }
            catch (Exception)
            {

                throw;
            }
         
        }

        public T Resolve<T>()
        {
            return GetInstance<T>();
        }

        bool CheckObjRef(string contractName)
        {
            bool result = false;
            foreach (KeyValuePair<string, object> item in _ioCContainerDictionary)
            {
                if (item.Key == contractName)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        T GetInstance<T>()
        {
            var result = new object();
            var contractName = typeof(T).Name;
            foreach (KeyValuePair<string, object> item in _ioCContainerDictionary)
            {
                if (item.Key == contractName)
                {
                    result = item.Value;
                    break;
                }
            }
            return (T)result;
        }

    }
}

