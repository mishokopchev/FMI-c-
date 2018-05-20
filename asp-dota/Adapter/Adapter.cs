using System;
namespace aspdota.Adapter
{
    public interface Adapter<T,L>
    {
        T Adapt(L obj);
    }
}
