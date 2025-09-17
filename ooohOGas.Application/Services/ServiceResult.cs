public class ServiceResult<T>
{
    public bool Success { get; private set; }
    public string[] Errors { get; private set; } = [];
    public T? Data { get; private set; }

    public static ServiceResult<T> Ok(T data) =>
        new ServiceResult<T> { Success = true, Data = data };

    public static ServiceResult<T> Fail(params string[] errors) =>
        new ServiceResult<T> { Success = false, Errors = errors };
}
