import type {
  GetWholeDirectorySturctureResponseModel,
  UploadFileRequestModel,
  UploadFileResponseModel,
} from '@proxy/file-uploader-saver';
import { RestService, Rest } from '@abp/ng.core';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class FileUploadProxyService {
  apiName = 'Default';
  baseUrl = `${environment.baseUrl}`;

  uploadFileByFileData = (FileData: any, config?: Partial<Rest.Config>) =>
    this.restService.request<any, string>(
      {
        method: 'POST',
        responseType: 'text',
        url: '/FileUploaderSaver/UploadFile',
        body: FileData,
      },
      { apiName: this.apiName, ...config }
    );

  constructor(private restService: RestService, private http: HttpClient) {}

  public ActualFileUpload(FileData: UploadFileRequestModel, url: string): Observable<any> {
    const formData = new FormData();
    for (const prop in FileData) {
      if (!FileData.hasOwnProperty(prop)) {
        continue;
      }
      formData.append(prop, FileData[prop]);
    }
    return this.http
      .post<any>(url, formData)
      .pipe(map(x => true));
  }

  // public ActualFileUploadChat(FileData: UploadFileRequestModel): Observable<any> {
  //   const formData = new FormData();
  //   for (const prop in FileData) {
  //     if (!FileData.hasOwnProperty(prop)) {
  //       continue;
  //     }
  //     formData.append(prop, FileData[prop]);
  //   }
  //   return this.http
  //     .post<any>(`http://10.20.61.83:5000/api/FileSaver/UploadFile`, formData)
  //     .pipe(map(x => true));
  // }


  public GetWholeDirectorySturcture(): Observable<GetWholeDirectorySturctureResponseModel[]> {
    return this.http.get<any>(
      `https://localhost:44335/FileUploaderSaver/GetWholeDirectorySturcture`
    );
  }
  public DownloadDocument(folderName: string, fileName: string): Observable<any> {
    let checkFileType = fileName.split('.').pop();
    var fileType;
    if (checkFileType == "txt") {
        fileType = "text/plain";
    }
    if (checkFileType == "pdf") {
        fileType = "application/pdf";
    }
    if (checkFileType == "doc") {
        fileType = "application/vnd.ms-word";
    }
    if (checkFileType == "docx") {
        fileType = "application/vnd.ms-word";
    }
    if (checkFileType == "xls") {
        fileType = "application/vnd.ms-excel";
    }
    if (checkFileType == "png") {
        fileType = "image/png";
    }
    if (checkFileType == "jpg") {
        fileType = "image/jpeg";
    }
    if (checkFileType == "jpeg") {
        fileType = "image/jpeg";
    }
    if (checkFileType == "gif") {
        fileType = "image/gif";
    }
    if (checkFileType == "csv") {
        fileType = "text/csv";
    }
    return this.http.get(`https://localhost:44335/FileUploaderSaver/DownloadDocument?FolderName=09cfb96f-8d9e-42ae-abbf-d07a1d2fc804&FileName=report%20%2863%29%20%281%29.pdf`, {
      params: { FolderName: folderName, FileName: fileName }, responseType: "blob", observe: 'response'
    }).pipe(
      map((res: any) => {
          return new Blob([res.body], { type: fileType });
      })
  );
  }
}
