import { AfterViewInit, Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ChatScreenService, IWindow, Message, chatScreenChatInterface, sendMessageResponse } from './chst-screen.service';
import { FileUploadProxyService } from '../shared/FileUploadProxy.service';
import {
  FileUploaderSaverService,
  GetEmSampleDataResponse,
  GetPMSampleDataResponse,
  GetWholeDirectorySturctureResponseModel,
} from '@proxy/file-uploader-saver';
import { Observable, Subscription } from 'rxjs';
import { NgbDropdownConfig } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-chat-screen',
  templateUrl: './chat-screen.component.html',
  styleUrl: './chat-screen.component.scss',
})
export class ChatScreenComponent implements OnInit, AfterViewInit, OnDestroy {
  chatForm: FormGroup;
  chatScreenChatData: chatScreenChatInterface[] = [];
  isFileSelectionModelOpen: boolean = false;
  listOfFiles: string[] = [];
  fileForm: FormGroup;
  currentSelectedFiles: string[] = [];
  showloader: boolean = false;
  view: any[] = [700, 400];
  colorScheme = {
    domain: ['#FAEF9B', '#F6D776', '#6DA4AA', '#647D87'],
  };
  gradient: boolean = false;
  showLegend: boolean = false;
  showLabels: boolean = true;
  isDoughnut: boolean = false;
  legendPosition: string = 'top';
  data = [];
  chartData = [];
  ShowChart: boolean[] = [];
  results: any;
  subscription;
  disableRecordingButton: boolean = false;
  isMagicWordCalled = false;
  isListenButtonClicked = false;
  stopListening = false;
  suggestionForChatList: string[] = ['Show Daily Monitoring.', 'Show EM/PM sample status.'];
  showPMSampleDataChart = false;
  showEMSampleDataChart = false;
  showPMSampleDataChartArray: boolean[] = [];
  showEMSampleDataChartArray: boolean[] = [];
  PMSampleDataForBoard: GetPMSampleDataResponse[][] = [];
  EMSampleDataForBoard: GetEmSampleDataResponse[][] = [];
  messages: Message[] = [];
  $sendMessageSubscription: Subscription;
  isImageModelOpen: boolean = false;
  currentImage: string = "";


  constructor(
    private fb: FormBuilder,
    // private fileUploadSaverProxyService: FileUploadProxyService,
    private fileUploadSaverService: FileUploaderSaverService,
    private service: ChatScreenService,
    config: NgbDropdownConfig
  ) {
    // config.placement = 'top-start';
    // config.autoClose = false;
    this.service.jsonDataTest.forEach(x => {
      this.data.push({ name: x.SampleType, value: x.count });
    });
  }
  ngOnDestroy(): void {
    this.stopListening = true;
    this.stopListeningWebKit();
  }
  ngAfterViewInit(): void {
    this.startListening();
  }
  ngOnInit(): void {
    this.chatForm = this.fb.group({
      userMessage: [],
      returnResponseType: [1],
    });
  }

  sendUserMessage() {
    let userMessage: string = this.chatForm.controls.userMessage.value ?? '';
    let chat: chatScreenChatInterface = {
      message: this.chatForm.controls.userMessage.value,
      messageType: 1,
      dateTime: new Date()
    };
    this.chatScreenChatData.push(chat);
    this.ShowChart.push(false);
    this.chartData.push([]);
    this.showPMSampleDataChartArray.push(false);
    this.showEMSampleDataChartArray.push(false);
    this.PMSampleDataForBoard.push([]);
    this.EMSampleDataForBoard.push([]);

    // let chat2: chatScreenChatInterface = {
    //   message: "Response",
    //   messageType: 2,
    // };
    // this.chatScreenChatData.push(chat2);
    this.showloader = true;
    if (this.showPMSampleDataChart == true || this.showEMSampleDataChart == true) {
      setTimeout(() => {
        this.ShowChart.push(false);
        this.chartData.push([]);
        if (this.showPMSampleDataChart == true) {
          this.showPMSampleDataChartArray.push(true);
          this.showEMSampleDataChartArray.push(false);
        } else if (this.showEMSampleDataChart == true) {
          this.showPMSampleDataChartArray.push(false);
          this.showEMSampleDataChartArray.push(true);
        }

        this.showPMSampleDataChart = false;
        this.showEMSampleDataChart = false;
        let chat2: chatScreenChatInterface = {
          message: '',
          messageType: 2,
          dateTime: new Date()
        };
        this.chatScreenChatData.push(chat2);
        setTimeout(() => {
          this.scroolToBottom();
        }, 100);
        this.showloader = false;
        this.showPMSampleDataChart = false;
        this.showEMSampleDataChart = false;
      }, 500);
    } else if (this.chatForm.controls.returnResponseType.value == 1) {
      this.subscription = this.fileUploadSaverService
        .sendUserMessageToApiByMessage(this.chatForm.controls.userMessage.value)
        .subscribe(
          x => {
            let chat2: chatScreenChatInterface = {
              message: x,
              messageType: 2,
              dateTime: new Date()
            };
            this.chatScreenChatData.push(chat2);
            this.ShowChart.push(false);
            this.chartData.push([]);
            this.showPMSampleDataChartArray.push(false);
            this.showEMSampleDataChartArray.push(false);
            this.PMSampleDataForBoard.push([]);
            this.EMSampleDataForBoard.push([]);
            // if(userMessage.includes("chart"))
            // {
            //   this.ShowChart.push(true);
            // }
            // else
            // {
            //   this.ShowChart.push(false)
            // }
            setTimeout(() => {
              this.scroolToBottom();
            }, 100);
            this.showloader = false;
            this.subscription.unsubscribe();
          },
          error => {
            this.showloader = false;
            let chat2: chatScreenChatInterface = {
              message: 'Something went wrong.',
              messageType: 2,
              dateTime: new Date()
            };
            this.chatScreenChatData.push(chat2);
            setTimeout(() => {
              this.scroolToBottom();
            }, 100);
            this.clickOnDiv();
            this.subscription.unsubscribe();
          }
        );
      this.showPMSampleDataChart = false;
      this.showEMSampleDataChart = false;
    } else if (this.chatForm.controls.returnResponseType.value == 2) {
      setTimeout(() => {
        this.ShowChart.push(true);
        this.chartData.push(this.data);
        this.showPMSampleDataChartArray.push(false);
        this.showEMSampleDataChartArray.push(false);
        this.PMSampleDataForBoard.push([]);
        this.EMSampleDataForBoard.push([]);
        let chat2: chatScreenChatInterface = {
          message: '',
          messageType: 2,
          dateTime: new Date()
        };
        this.chatScreenChatData.push(chat2);
        setTimeout(() => {
          this.scroolToBottom();
        }, 100);
        this.showloader = false;
      }, 500);
      this.showPMSampleDataChart = false;
      this.showEMSampleDataChart = false;
    }

    setTimeout(() => {
      this.scroolToBottom();
    }, 100);
    this.chatForm.controls.userMessage.reset();
  }

  sendMessage() {
    if (this.chatForm.controls.userMessage.value.trim() === '') return;
    let responseType: number = this.chatForm.controls.returnResponseType.value ?? 1;
    this.showloader = true;
    this.messages.push({
      content: this.chatForm.controls.userMessage.value,
      df: '',
      img: '',
      from: 'user',
      messageType: 1,
      dateTime: new Date()
    });
    this.$sendMessageSubscription = this.service.sendMessage(this.chatForm.controls.userMessage.value).subscribe(
      (response) => {
        const tableHtml = this.formatDataFrameAsTable(JSON.parse(response.df));
        let content: Message = {
          content: response.text,
          df: tableHtml,
          img: response.fig,
          from: 'assistant',
          messageType: 2,
          dateTime: new Date()
        }
        if (responseType != 1) {
          content = {
            content: responseType == 2 ? response.text : '',
            df: responseType == 4 ? tableHtml : null,
            img: responseType == 3 ? response.fig : null,
            from: 'assistant',
            messageType: 2,
            dateTime: new Date()
          }
        }
        this.messages.push(content);
        setTimeout(() => {
          this.scroolToBottom();
        }, 100);
        this.showloader = false;
      },
      (error) => {
        console.error('Error occurred while sending message to Flask backend:', error);
        this.showloader = false;
      }
    );
    this.chatForm.controls.userMessage.reset();
    setTimeout(() => {
      this.scroolToBottom();
    }, 100);
  }

  private formatDataFrameAsTable(dataframe: any[]): string {
    if (!dataframe || dataframe.length === 0) {
      return '';
    }

    let table = '<table><thead><tr>';
    for (let column of Object.keys(dataframe[0])) {
      table += '<th>' + column + '</th>';
    }
    table += '</tr></thead><tbody>';

    for (let row of dataframe) {
      table += '<tr>';
      for (let column of Object.values(row)) {
        table += '<td>' + column + '</td>';
      }
      table += '</tr>';
    }

    table += '</tbody></table>';
    return table;
  }

  openFileSelectionModel() {
    let subscription: Subscription = this.fileUploadSaverService
      .getListOfFilesFromDir()
      .subscribe(x => {
        this.buildingFileForm();
        this.listOfFiles = x;
        this.isFileSelectionModelOpen = true;
        subscription.unsubscribe();
      });
  }

  buildingFileForm() {
    this.fileForm = this.fb.group({
      selectedFiles: [],
    });
  }

  sendFilesToApi() {
    let selectedFiles = this.fileForm.controls.selectedFiles.value;
    if (selectedFiles) {
      if (selectedFiles.length) {
        this.currentSelectedFiles = [];
        // let chat: chatScreenChatInterface = {
        //   message: 'Selected file: ',
        //   messageType: 2,
        // };
        // this.chatScreenChatData.push(chat);
        selectedFiles.forEach(file => {
          this.currentSelectedFiles.push(file);
          // this.chatScreenChatData.push({
          //   message: file,
          //   messageType: 2,
          // });
        });
      }
    }
    this.isFileSelectionModelOpen = false;
    // setTimeout(() => {
    //   this.scroolToBottom(), 100;
    // });
  }

  scroolToBottom() {
    var objDiv = document.getElementById('ChatScreen');
    objDiv.scrollTop = objDiv.scrollHeight;
    this.clickOnDiv();
  }

  clearChatHistory() {
    this.showloader = false;
    this.stopSendMessage();
    this.chatScreenChatData = [];
    this.chartData = [];
    this.ShowChart = [];
    this.showPMSampleDataChartArray = [];
    this.showEMSampleDataChartArray = [];
    this.PMSampleDataForBoard = [];
    this.EMSampleDataForBoard = [];
    // this.subscription.unsubscribe();
    this.showloader = false;
    this.messages = [];
  }
  clearSelectedFiles() {
    this.currentSelectedFiles = [];
  }

  startListening() {
    // let voiceHandler = this.hiddenSearchHandler?.nativeElement;
    if ('webkitSpeechRecognition' in window) {
      const { webkitSpeechRecognition }: IWindow = <IWindow>window;
      const recognition = new webkitSpeechRecognition();
      const vSearch = new webkitSpeechRecognition();
      vSearch.continuous = false;
      vSearch.interimresults = false;
      vSearch.lang = 'en-US';
      vSearch.start();
      vSearch.onresult = e => {
        // voiceHandler.value = e?.results[0][0]?.transcript;
        this.results = e.results[0][0].transcript;
        this.disableRecordingButton = false;
        //this.chatForm.controls.userMessage.setValue(this.results);
        if (
          this.results.includes('hey caliber') ||
          this.results.includes('hey calibre') ||
          this.results.includes('a calibre') ||
          this.results.includes('hey caliban') ||
          this.results.includes('hey caliper') ||
          this.results.includes('a caliper')
        ) {
          this.isMagicWordCalled = true;
          this.clickonisListeningDiv();
          this.clickOnDiv();
        } else if (
          !(
            this.results.includes('hey caliber') ||
            this.results.includes('hey calibre') ||
            this.results.includes('a calibre') ||
            this.results.includes('hey caliban') ||
            this.results.includes('hey caliper') ||
            this.results.includes('a caliper')
          ) &&
          (this.isMagicWordCalled == true || this.isListenButtonClicked == true)
        ) {
          this.isMagicWordCalled = false;
          this.isListenButtonClicked = false;
          this.clickonisListeningDiv();
          this.chatForm.controls.userMessage.setValue(this.results);
          this.getResult();
          this.clickOnDiv();
        }
      };
      vSearch.onend = e => {
        if (this.stopListening != true) {
          vSearch.start();
        }
      };
      this.disableRecordingButton = false;
    } else {
      alert('Your browser does not support voice to text!');
    }
  }

  getResult() {
    this.sendUserMessage();
    setTimeout(() => {
      this.scroolToBottom();
      this.clickOnDiv();
    }, 100);
  }

  clickOnDiv() {
    if (document.contains(document.getElementById('ChatScreen'))) {
      document.getElementById('ChatScreen').click();
      var objDiv = document.getElementById('ChatScreen');
      objDiv.scrollTop = objDiv.scrollHeight;
    }
  }
  clickonisListeningDiv() {
    if (document.contains(document.getElementById('isListening'))) {
      document.getElementById('isListening').click();
      var objDiv = document.getElementById('ChatScreen');
      objDiv.scrollTop = objDiv.scrollHeight;
    }
  }

  stopListeningWebKit() {
    if ('webkitSpeechRecognition' in window) {
      const { webkitSpeechRecognition }: IWindow = <IWindow>window;
      const recognition = new webkitSpeechRecognition();
      const vSearch = new webkitSpeechRecognition();
      vSearch.stop();
    }
  }

  ContinusVoiceListen() { }

  SendQuestion(Question: string) {
    if (Question == 'Show EM/PM sample status.') {
      let $subscription: Observable<GetPMSampleDataResponse[]> =
        this.fileUploadSaverService.getPMSampleData();
      let subscription: Subscription = $subscription.subscribe(x => {
        this.showPMSampleDataChart = true;
        // this.showPMSampleDataChartArray.push(true);
        // this.showEMSampleDataChartArray.push(false);
        this.PMSampleDataForBoard.push(x);
        this.EMSampleDataForBoard.push([]);
        this.chatForm.controls.userMessage.setValue(Question);
        this.sendUserMessage();
        subscription.unsubscribe();
      });
    } else if ('Show Daily Monitoring.') {
      let $subscription: Observable<GetEmSampleDataResponse[]> =
        this.fileUploadSaverService.getEmSampleData();
      let subscription: Subscription = $subscription.subscribe(x => {
        this.showEMSampleDataChart = true;
        // this.showPMSampleDataChartArray.push(false);
        // this.showEMSampleDataChartArray.push(true);
        this.EMSampleDataForBoard.push(x);
        this.PMSampleDataForBoard.push([]);
        this.chatForm.controls.userMessage.setValue(Question);
        this.sendUserMessage();
        subscription.unsubscribe();
      });
    }
  }

  isCallRunning(): boolean {
    return!(
      // this.chatForm.controls.userMessage.value != null &&
      this.chatForm.controls.returnResponseType.value != null &&
      this.showloader != true
    )
  }


  stopSendMessage()
  {
    this.$sendMessageSubscription.unsubscribe();
    setTimeout(() => {
      this.scroolToBottom();
    }, 100);
    this.showloader = false;
  }

}
