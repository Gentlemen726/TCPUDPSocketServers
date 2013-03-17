using System;
using Dem0n13.Utils;

namespace Dem0n13.SocketServer
{
    public sealed class UdpClientArgsPool : Pool<UdpClientArgs>
    {
        private readonly int _bufferSize;

        public UdpClientArgsPool(int initialCount, int bufferSize)
        {
            if (initialCount < 0)
                throw new ArgumentException("��������� ���������� ��������� �� ����� ���� �������������", "initialCount");
            if (bufferSize < 1)
                throw new ArgumentException("������ ������ ����� �������� �������� " + bufferSize, "bufferSize");

            _bufferSize = bufferSize;
            Allocate(initialCount);
        }

        protected override UdpClientArgs CreateNew()
        {
            return new UdpClientArgs(_bufferSize);
        }

        protected override void CleanUp(UdpClientArgs item)
        {
            item.UTF8Message = null;
        }
    }
}
