import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { AfterViewInit, ElementRef, ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
// import * as Plotly from 'plotly.js';

interface Message {
  df : string;
  img : any;
  content: string;
  from: 'user' | 'assistant';
}

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Component({
  selector: 'app-user-input',
  templateUrl: './user-input.component.html',
  styleUrls: ['./user-input.component.scss']
})

export class UserInputComponent {
  messages: Message[] = [];
  newMessage: string = '';
  tableHtml: string = '';
  total_msg: number=0;

  @ViewChild('chatMessages') private chatMessages: ElementRef;
  constructor(private http: HttpClient) {}

  sendMessage() {
    if (this.newMessage.trim() === '') return;

    this.messages.push({ content: this.newMessage,df: '', img: '', from: 'user' });

    this.http.get<any>('http://10.20.61.83:8084/api/v0/ask', { params: { question: this.newMessage } }).subscribe(
      (response) => {
        // Handle response from Flask backend

        const tableHtml = this.formatDataFrameAsTable(JSON.parse(response.df));
        this.messages.push({ content: response.text,df :tableHtml, img: response.fig, from: 'assistant' }); // Assuming text is the response from Flask
        this.scrollToBottom();
      },
      (error) => {
        console.error('Error occurred while sending message to Flask backend:', error);
        // Handle error if necessary
      }
    );
    this.newMessage = '';

    // Scroll to bottom of chat messages
    this.scrollToBottom();

    // Here you would send the user's message to your backend or process it in some way
    // and get a response from your ChatGPT model or whatever AI you're using
    // For this example, let's simulate a response after a short delay

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
  scrollToBottom() {
    this.chatMessages.nativeElement.scrollTop = this.chatMessages.nativeElement.scrollHeight;
  }

//   // userInput: string = '';
//   @ViewChild("chart") chart: ChartComponent;
//   public chartOptions: Partial<ChartOptions>;

//   InputForm=this.fb.group(
//     {
//       userInput:['']
//     }
//   )
//   countOccurrences(strings: string[]): { x: string, y: number }[] {
//     const counts: { [key: string]: number } = {};

//     // Count occurrences of each string
//     strings.forEach(str => {
//         counts[str] = (counts[str] || 0) + 1;
//     });

//     // Convert counts object into array of objects with "x" and "y" keys
//     const result: { x: string, y: number }[] = [];
//     for (const key in counts) {
//         result.push({ x: key, y: counts[key] });
//     }

//     return result;
// }


//   ngOnInit(){
//     this.chartOptions = {
//       series: [
//         {
//           name: "sample",
//           data: [1,2,3,4,5]
//         }
//       ],
//       chart: {
//         height: 500,
//         width: 650,
//         type: "line",

//         toolbar: {
//           show: false
//         },
//       }
//   }
// }

//   constructor(private http: HttpClient,private fb : FormBuilder) { }
//   datalist: any[]=[];
//   onSubmit() {

//     this.http.post<string>('http://localhost:5000/api/generate_chart', JSON.stringify(this.InputForm.value.userInput),httpOptions).subscribe(response => {
//       // Process the response from the backend, if needed
//       this.datalist=response["message"];
//       let typechart=this.datalist[this.datalist.length-1];
//       this.datalist=this.datalist.slice(0,this.datalist.length-1);
//       if(typeof this.datalist[0]==="string")
//       {

//         this.datalist=this.countOccurrences(this.datalist);;
//       }
//       this.chartOptions = {
//         series: [
//           {
//             name: "sample",
//             data: this.datalist
//           }
//         ],
//         chart: {
//           height: 500,
//           width: 650,
//           type: typechart,

//           toolbar: {
//             show: false
//           },
//         }

//       };
//     });
//   }
}
