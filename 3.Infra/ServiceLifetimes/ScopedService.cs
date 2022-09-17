using Core;

namespace Infra;

public class ScopedService : IScopedService
{
    private int _requestedCount;
    public ScopedService() {}

    public int GetRequestedCount()
    {
        _requestedCount = _requestedCount + 1;
        return _requestedCount;
    }
}
