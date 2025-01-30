namespace Persistence;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using Core.Contracts;

using System.Threading.Tasks;

using Core.QueryResults;

using System.IO;

/// <summary>
/// TODO
/// </summary>
public class ImportController : IImportController
{
    public Task<IEnumerable<CsvFile>> GetNotImportedFilesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<int> ImportCsvFileAsync(CsvFile csvFile)
    {
        throw new NotImplementedException();
    }
}