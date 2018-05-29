using System;
namespace aspdota.Adapter
{
    public interface IAdapter<T,L>
    {
        T Adapt(L obj); 
    }
}
