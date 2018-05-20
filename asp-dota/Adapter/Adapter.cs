using System;
namespace aspdota.Adapter
{
    public interface Adapter<T,L>
    {
        L adapt(T obj);
    }
}
