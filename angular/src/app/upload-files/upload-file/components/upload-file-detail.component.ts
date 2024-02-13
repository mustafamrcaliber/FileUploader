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
    private fileUploadSaverService: FileUploaderSaverService,
    private fileUploadSaverProxyservice: FileUploadProxyService,
    private fb: FormBuilder
  ) // private chatScreenService: ChatScreenService,
  {
    this.fileUploadForm = this.fb.group({
      FileInputField: [null, Validators.required],
    });
  }
  ngOnInit(): void {}

  onFileselection(event) {
    if (event.target.files.length > 0) {
      this.selectedFile = <File>event.target.files[0];
    }
  }
  uploadFile() {
    let FileForm: UploadFileRequestModel = {
      file: this.selectedFile,
      filePath: 'sfgdf',
    };
    let $uploadFileNameChatSubs = this.fileUploadSaverService.uploadFileToChatByFileName(
      FileForm.file.name
    );
    let $getUrlForFileUpload = this.fileUploadSaverService.getUrlToUploadFile();

    let subscriptionOne = $getUrlForFileUpload.subscribe(x => {
      let $uploadFile = this.fileUploadSaverProxyservice.ActualFileUpload(FileForm, x);
      let subscriptionTwo = $uploadFile.subscribe(y => {
        $uploadFileNameChatSubs.subscribe(z => {});
        subscriptionOne.unsubscribe();
        this.service.list.get();
        this.service.hideForm();
      });
    });
  }
}
