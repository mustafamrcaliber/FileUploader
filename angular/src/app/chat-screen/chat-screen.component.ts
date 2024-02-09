import { AfterViewInit, Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ChatScreenService, IWindow, chatScreenChatInterface } from './chst-screen.service';
import { FileUploadProxyService } from '../shared/FileUploadProxy.service';
import { GetWholeDirectorySturctureResponseModel } from '@proxy/file-uploader-saver';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-chat-screen',
  templateUrl: './chat-screen.component.html',
  styleUrl: './chat-screen.component.scss',
})
export class ChatScreenComponent implements OnInit, AfterViewInit, OnDestroy {
  chatForm: FormGroup;
  chatScreenChatData: chatScreenChatInterface[] = [];
  isFileSelectionModelOpen: boolean = false;
  listOfFiles: GetWholeDirectorySturctureResponseModel[] = [];
  fileForm: FormGroup;
  currentSelectedFiles: string[] = [];
  showloader: boolean = false;
  view: any[] = [700, 400];
  colorScheme = {
    domain: ['#FAEF9B', '#F6D776', '#6DA4AA', '#647D87']
  };
  gradient: boolean = false;
  showLegend: boolean = false;
  showLabels: boolean = true;
  isDoughnut: boolean = false;
  legendPosition: string = 'top';
  data = [];
  chartData = []
  ShowChart: boolean[] = [];
  results:any;
  subscription;
  disableRecordingButton: boolean = false;
  isMagicWordCalled = false;
  isListenButtonClicked = false;
  stopListening = false;

  constructor(
    private fb: FormBuilder,
    private fileUploadSaverProxyService: FileUploadProxyService,
    private service: ChatScreenService
  ) {
    this.service.jsonDataTest.forEach( x=>{
      this.data.push({"name": x.SampleType, value: x.count})
    })
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
      returnResponseType: [1]
    });
  }

  sendUserMessage() {
    let userMessage: string =  this.chatForm.controls.userMessage.value?? "";
    let chat: chatScreenChatInterface = {
      message: this.chatForm.controls.userMessage.value,
      messageType: 1,
    };
    this.chatScreenChatData.push(chat);
    this.ShowChart.push(false);
    this.chartData.push([]);
    // let chat2: chatScreenChatInterface = {
    //   message: "Response",
    //   messageType: 2,
    // };
    // this.chatScreenChatData.push(chat2);
    this.showloader = true;
    if(this.chatForm.controls.returnResponseType.value == 1)
    {
      this.subscription = this.service.sendUserMessageToApi(this.chatForm.controls.userMessage.value).subscribe(
        x =>
        {
          let chat2: chatScreenChatInterface = {
            message: x,
            messageType: 2,
          };
          this.chatScreenChatData.push(chat2);
          this.ShowChart.push(false);
          this.chartData.push([]);
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
        }, error =>
        {
          this.showloader = false;
          let chat2: chatScreenChatInterface = {
            message: "Something went wrong.",
            messageType: 2,
          };
          this.chatScreenChatData.push(chat2);
          setTimeout(() => {
            this.scroolToBottom();
          }, 100);
          this.clickOnDiv();
          this.subscription.unsubscribe();
        }
      )
    }
    else if(this.chatForm.controls.returnResponseType.value == 2)
    {
      setTimeout(() => {
        this.ShowChart.push(true);
      this.chartData.push(this.data);
      let chat2: chatScreenChatInterface = {
              message: "",
              messageType: 2,
            };
            this.chatScreenChatData.push(chat2);
            setTimeout(() => {
              this.scroolToBottom();
            }, 100);
            this.showloader = false;
      }, 500);
      // this.ShowChart.push(true);
      // this.chartData.push(this.data);
      // let chat2: chatScreenChatInterface = {
      //         message: "",
      //         messageType: 2,
      //       };
      //       this.chatScreenChatData.push(chat2);
      //       setTimeout(() => {
      //         this.scroolToBottom();
      //       }, 100);
      //       this.showloader = false;
      // let $chartQuery = this.service.sendUserMessafeToApiAndGetJsonChart(this.chatForm.controls.userMessage.value);
      // let chartQuery = $chartQuery.subscribe( chartCall =>
      //   {
      //     let chat2: chatScreenChatInterface = {
      //       message: chartCall,
      //       messageType: 2,
      //     };
      //     this.chatScreenChatData.push(chat2);
      //     console.log(chartCall , "chartCall");
      //     setTimeout(() => {
      //       this.scroolToBottom();
      //     }, 100);
      //     this.showloader = false;
      //     chartQuery.unsubscribe();
      //   },
      //   error =>
      //   {
      //     this.showloader = false;
      //     let chat2: chatScreenChatInterface = {
      //       message: "Something went wrong.",
      //       messageType: 2,
      //     };
      //     this.chatScreenChatData.push(chat2);
      //     setTimeout(() => {
      //       this.scroolToBottom();
      //     }, 100);
      //   })
    }

    setTimeout(() => {
      this.scroolToBottom();
    }, 100);
    this.chatForm.controls.userMessage.reset();
  }

  openFileSelectionModel() {
    let subscription: Subscription = this.fileUploadSaverProxyService
      .GetWholeDirectorySturcture()
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
        this.currentSelectedFiles =[];
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

  clearChatHistory()
  {
    this.chatScreenChatData = [];
    this.chartData = [];
    this.ShowChart = [];
    this.subscription.unsubscribe();
    this.showloader = false;
  }
  clearSelectedFiles()
  {
    this.currentSelectedFiles = []
  }

  startListening() {
    // let voiceHandler = this.hiddenSearchHandler?.nativeElement;
    if ('webkitSpeechRecognition' in window) {
      const {webkitSpeechRecognition} : IWindow = <IWindow>window;
const recognition = new webkitSpeechRecognition();
      const vSearch = new webkitSpeechRecognition();
      vSearch.continuous = false;
      vSearch.interimresults = false;
      vSearch.lang = 'en-US';
      vSearch.start();
      vSearch.onresult = (e) => {
        // voiceHandler.value = e?.results[0][0]?.transcript;
        this.results = e.results[0][0].transcript;
        this.disableRecordingButton = false;
        //this.chatForm.controls.userMessage.setValue(this.results);
        if((this.results.includes("hey caliber") ||  this.results.includes("hey calibre") || this.results.includes("a calibre") || this.results.includes("hey caliban") || this.results.includes("hey caliper") || this.results.includes("a caliper")))
        {
          this.isMagicWordCalled = true;
          this.clickonisListeningDiv();
        }
        else if(!(this.results.includes("hey caliber") ||  this.results.includes("hey calibre") || this.results.includes("a calibre") || this.results.includes("hey caliban") || this.results.includes("hey caliper") || this.results.includes("a caliper")) && (this.isMagicWordCalled == true || this.isListenButtonClicked == true))
        {
          this.isMagicWordCalled = false;
          this.isListenButtonClicked = false;
          this.clickonisListeningDiv();
          this.chatForm.controls.userMessage.setValue(this.results);
          this.getResult();
          this.clickOnDiv();
        }
      };
      vSearch.onend = (e) => {
        if(this.stopListening != true)
        {
          vSearch.start();
        }
      }
      this.disableRecordingButton = false;
    } else {
      alert('Your browser does not support voice to text!');
    }
  }

  getResult(){
    this.sendUserMessage();
    setTimeout(() => {
      this.scroolToBottom();
      this.clickOnDiv();
    }, 100);
  }

  clickOnDiv()
  {
    if (document.contains(document.getElementById('ChatScreen'))) {
      document.getElementById('ChatScreen').click();
      var objDiv = document.getElementById('ChatScreen');
    objDiv.scrollTop = objDiv.scrollHeight;
    }
  }
  clickonisListeningDiv()
  {
    if (document.contains(document.getElementById('isListening'))) {
      document.getElementById('isListening').click();
      var objDiv = document.getElementById('ChatScreen');
    objDiv.scrollTop = objDiv.scrollHeight;
    }
  }

  stopListeningWebKit(){
    if ('webkitSpeechRecognition' in window) {
      const {webkitSpeechRecognition} : IWindow = <IWindow>window;
const recognition = new webkitSpeechRecognition();
      const vSearch = new webkitSpeechRecognition();
      vSearch.stop();
    }
  }

  ContinusVoiceListen()
  {

  }
}
