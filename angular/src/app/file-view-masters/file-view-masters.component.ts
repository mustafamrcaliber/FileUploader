import { Component, OnInit } from '@angular/core';
import { GetWholeDirectorySturctureResponseModel } from '@proxy/file-uploader-saver';
import { FileUploadProxyService } from '../shared/FileUploadProxy.service';
import { Subscription } from 'rxjs';
import { NgbAccordionModule } from '@ng-bootstrap/ng-bootstrap';
import { downloadBlob } from '@abp/ng.core';

@Component({
  selector: 'app-file-view-masters',
  providers: [NgbAccordionModule],
  templateUrl: './file-view-masters.component.html',
  styleUrl: './file-view-masters.component.scss'
})
export class FileViewMastersComponent implements OnInit{
  files: GetWholeDirectorySturctureResponseModel[] = [];
  constructor(private fileuploadProxyService: FileUploadProxyService,

    public ngbAccordionModule: NgbAccordionModule,)
  {

  }
  ngOnInit(): void {
    let subscription: Subscription =  this.fileuploadProxyService.GetWholeDirectorySturcture().subscribe( x=>
      {
        this.files = x;
        console.log(this.files)
        subscription.unsubscribe();
      })
  }

  downloadDocument(FolderName: string, FileName:string)
  {
    let subscription: Subscription = this.fileuploadProxyService.DownloadDocument(FolderName, FileName).subscribe( x=>{
      console.log(x, "Xxxxxxx")
      downloadBlob(x, FileName)
      subscription.unsubscribe();
    })
  }

}
