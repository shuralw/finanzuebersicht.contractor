import { Observable, Observer } from 'rxjs';
import * as jschardet from 'jschardet';

export class CsvParserConfig {
    header?: boolean;
    delimiter?: string;
}

export class CsvParserError {
    type: string;
    code: number;
    message: string;
}

export type CsvDictionary = {
    [key: string]: string;
};

export async function parseCsv(file: File): Promise<CsvDictionary[]> {
    const csvParser = new CsvParser();
    const csvData = await csvParser.parse(file, {
        header: true
    }).toPromise();

    if (csvData instanceof CsvParserError) {
        throw csvData;
    }

    return csvData as CsvDictionary[];
}

export class CsvParser {

    private defaultCsvParserConfig = {
        header: true
    };

    public parse(csvFile: File, config: CsvParserConfig): Observable<Array<any> | CsvParserError> {

        config = {
            ...this.defaultCsvParserConfig,
            ...config
        };

        const ngxCsvParserObserver = new Observable((observer: Observer<Array<any> | CsvParserError>) => {
            try {
                let csvRecords = null;

                if (this.isCSVFile(csvFile)) {

                    const reader = new FileReader();
                    reader.readAsBinaryString(csvFile);

                    let firstRead = true;

                    reader.onload = () => {
                        const csvData = reader.result as string;
                        if (firstRead) {
                            const detection = jschardet.detect(csvData);
                            firstRead = false;
                            reader.readAsText(csvFile, detection.encoding);
                            return;
                        }

                        const csvRecordsArray = this.csvStringToArray(csvData.trim(), config.delimiter);

                        const headersRow = this.getHeaderArray(csvRecordsArray);

                        csvRecords = this.getDataRecordsArrayFromCSVFile(csvRecordsArray, headersRow.length, config);

                        observer.next(csvRecords);
                        observer.complete();
                    };

                    reader.onerror = () => {
                        this.badCSVDataFormatErrorHandler(observer);
                    };

                } else {
                    this.notCSVFileErrorHandler(observer);
                }

            } catch (error) {
                this.unknownCsvParserErrorHandler(observer);
            }
        });

        return ngxCsvParserObserver;
    }

    public csvStringToArray(csvDataString: string, delimiter?: string): any[][] {
        if (delimiter == null) {
            const commaCount = csvDataString.split('\n')[0].split(',').length;
            const semicolonCount = csvDataString.split('\n')[0].split(';').length;
            delimiter = (commaCount > semicolonCount) ? ',' : ';';
        }

        const regexPattern = new RegExp((`(\\${delimiter}|\\r?\\n|\\r|^)(?:\"((?:\\\\.|\"\"|[^\\\\\"])*)\"|([^\\${delimiter}\"\\r\\n]*))`), 'gi');
        let matchedPatternArray = regexPattern.exec(csvDataString);
        const resultCSV = [[]];
        while (matchedPatternArray) {
            if (matchedPatternArray[1].length && matchedPatternArray[1] !== delimiter) {
                resultCSV.push([]);
            }
            const cleanValue = matchedPatternArray[2] ?
                matchedPatternArray[2].replace(new RegExp('[\\\\\"](.)', 'g'), '$1') : matchedPatternArray[3];
            resultCSV[resultCSV.length - 1].push(cleanValue);
            matchedPatternArray = regexPattern.exec(csvDataString);
        }
        return resultCSV;
    }

    private getDataRecordsArrayFromCSVFile(csvRecordsArray: any, headerLength: any, config: any): string[] {
        const dataArr = [];
        const headersArray = csvRecordsArray[0];

        const startingRowToParseData = config.header ? 1 : 0;

        for (let i = startingRowToParseData; i < csvRecordsArray.length; i++) {
            const data = csvRecordsArray[i];

            if (data.length === headerLength && config.header) {

                const csvRecord = {};

                for (let j = 0; j < data.length; j++) {
                    if ((data[j] === undefined) || (data[j] === null)) {
                        csvRecord[headersArray[j]] = '';
                    } else {
                        csvRecord[headersArray[j]] = data[j].trim();
                    }
                }
                dataArr.push(csvRecord);
            } else {
                dataArr.push(data);
            }
        }
        return dataArr;
    }

    private isCSVFile(file: any): boolean {
        return file.name.toLowerCase().endsWith('.csv');
    }

    private getHeaderArray(csvRecordsArr: any): string[] {
        const headers = csvRecordsArr[0];
        const headerArray = [];
        for (const header of headers) {
            headerArray.push(header);
        }
        return headerArray;
    }

    private notCSVFileErrorHandler(observer: Observer<any>): void {
        const ngcCsvParserError: CsvParserError =
            this.errorBuilder('NOT_A_CSV_FILE', 'Selected file is not a csv File Type.', 2);
        observer.error(ngcCsvParserError);
    }

    private unknownCsvParserErrorHandler(observer: Observer<any>): void {
        const ngcCsvParserError: CsvParserError =
            this.errorBuilder('UNKNOWN_ERROR', 'Unknown error. Please refer to official documentation for library usage.', 404);
        observer.error(ngcCsvParserError);
    }

    private badCSVDataFormatErrorHandler(observer: Observer<any>): void {
        const ngcCsvParserError: CsvParserError =
            this.errorBuilder('BAD_CSV_DATA_FORMAT', 'Unable to parse CSV File.', 1);
        observer.error(ngcCsvParserError);
    }

    private errorBuilder(type: string, message: any, code: any): CsvParserError {
        const ngcCsvParserError: CsvParserError = new CsvParserError();
        ngcCsvParserError.type = type;
        ngcCsvParserError.message = message;
        ngcCsvParserError.code = code;
        return ngcCsvParserError;
    }
}
