using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Terminia.Models.Optimization
{
    public static class ArrayOptimizations
    {
        public static void Fill<T>(Array array, T value)
        {
            var data = MemoryMarshal.CreateSpan(
                ref Unsafe.As<byte, T>(ref MemoryMarshal.GetArrayDataReference(array)),
                array.Length);

            data.Fill(value);
        }
    }
}