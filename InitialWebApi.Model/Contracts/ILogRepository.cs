using InitialWebApi.Model.Models;

namespace InitialWebApi.Model.Contracts
{
    public interface ILogRepository
    {
        void Save(PipelineLogData logItem);
        PipelineLogData Get(string code);
    }
}
