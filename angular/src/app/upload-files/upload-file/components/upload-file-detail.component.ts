import { CoreModule } from '@abp/ng.core';
import { ThemeSharedModule, DateAdapter } from '@abp/ng.theme.shared';
import { CommercialUiModule } from '@volo/abp.commercial.ng.ui';
import { ChangeDetectionStrategy, Component, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { NgbDateAdapter, NgbDatepickerModule, NgbNavModule } from '@ng-bootstrap/ng-bootstrap';
import { UploadFileDetailViewService } from '../services/upload-file-detail.service';
import { FileUploaderSaverService, UploadFileRequestModel } from '@proxy/file-uploader-saver';
import { FileUploadProxyService } from 'src/app/shared/FileUploadProxy.service';
import { Observable, forkJoin } from 'rxjs';
import { ChatScreenService } from 'src/app/chat-screen/chst-screen.service';

@Component({
  selector: 'app-upload-file-detail-modal',
  changeDetection: ChangeDetectionStrategy.Default,
  standalone: true,
  imports: [
    CoreModule,
    ThemeSharedModule,
    CommercialUiModule,
    ReactiveFormsModule,
    NgbDatepickerModule,
    NgbNavModule,
  ],
  providers: [{ provide: NgbDateAdapter, useClass: DateAdapter }],
  templateUrl: './upload-file-detail.component.html',
  styles: [],
})
export class UploadFileDetailModalComponent implements OnInit {
  public readonly service = inject(UploadFileDetailViewService);
  fileUploadForm: FormGroup;
  selectedFile: File;

  constructor(
    private fileUploadSaverService: FileUploadProxyService,
    private fb: FormBuilder,
    private chatScreenService: ChatScreenService
  ) {
    this.fileUploadForm = this.fb.group({
      FileInputField: [null, Validators.required],
    });
  }
  ngOnInit(): void {}

  onFileselection(event) {
    if (event.target.files.length > 0) {
      // if(event.target.files[0].type != 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet')
      // {
      //   // this.importFromExcelForm.controls.FileInputField.setErrors({invalidType:true});
      // }
      // else
      // {
      this.selectedFile = <File>event.target.files[0];
      // }
    }
  }
  uploadFile() {
    let FileForm: UploadFileRequestModel = {
      file: this.selectedFile,
      filePath: 'sfgdf',
    };
    // const formData = new FormData();
    // for (const prop in FileForm) {
    //   if (!FileForm.hasOwnProperty(prop)) { continue; }
    //   formData.append(prop , FileForm[prop]);
    // }
    console.log(FileForm);

    let $uploadFile = this.fileUploadSaverService.ActualFileUpload(FileForm);
    let $uploadFileNameChatSubs = this.chatScreenService.uploadFileToChat(FileForm.file.name);
    let subscribeOne = $uploadFile.subscribe( x => {
      $uploadFileNameChatSubs.subscribe( y => {

      })
      subscribeOne.unsubscribe();
      this.service.list.get();
      this.service.hideForm();
    })
    // let fork = forkJoin([$uploadFile, $uploadFileNameChatSubs]).subscribe(x => {
    //   fork.unsubscribe();
    //   this.service.list.get();
    //   this.service.hideForm();
    // });

    // let $uploadFile = this.fileUploadSaverService.ActualFileUpload(FileForm);
    // let uploadFile = $uploadFile.subscribe(x => {
    //   let uploadFileNameChatSubs = this.chatScreenService
    //       .uploadFileToChat(FileForm.file.name)
    //       .subscribe(nameResponse => {
    //         uploadFileNameChatSubs.unsubscribe();
    //         uploadFile.unsubscribe();
    //       this.service.list.get();
    //       this.service.hideForm();
    //       });
    // });
  }
}
