import { RestService } from '@abp/ng.core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ChatScreenService {
  URL: string = 'http://10.20.61.83:5002/UserQuery/';
  public jsonDataTest = [
    { SampleType: 'In-progress Type', count: 85 },
    { SampleType: 'Report batch analysis', count: 18 },
    { SampleType: 'Batch Profile Analysis', count: 16 },
    { SampleType: 'COA print1', count: 13 },
    { SampleType: 'cqmprjdev1', count: 10 },
    { SampleType: 'Worksheet--1', count: 6 },
    { SampleType: 'Kworking', count: 4 },
    { SampleType: 'PRD_0823', count: 3 },
    { SampleType: 'Summary Report', count: 3 },
    { SampleType: 'SSUMMARY REPORT', count: 3 },
    { SampleType: 'Expert', count: 3 },
    { SampleType: 'Instrument Issue', count: 2 },
    { SampleType: 'TVTD_01', count: 2 },
    { SampleType: 'Time', count: 2 },
    { SampleType: 'WS2', count: 1 },
    { SampleType: 'View', count: 1 },
    { SampleType: 'vamsi', count: 1 },
    { SampleType: 'Spec', count: 1 },
    { SampleType: 'ReSDQTY', count: 1 },
    { SampleType: 'RAW MATERIAL', count: 1 },
    { SampleType: 'Coa related issue', count: 1 },
    { SampleType: 'AQ_Issue', count: 1 },
  ];
  constructor(private restService: RestService, private http: HttpClient) {}

  public sendMessage(newMessage):Observable<sendMessageResponse>
  {
    return this.http.get<sendMessageResponse>('http://10.20.61.83:8084/api/v0/ask', { params: { question: newMessage } });
  }

}

export interface chatScreenChatInterface {
  message: string;
  messageType: 1 | 2;
  dateTime: Date;
}

export interface IWindow extends Window {
  webkitSpeechRecognition: any;
}

export interface Message {
  df : string;
  img : any;
  content: string;
  from: 'user' | 'assistant';
  messageType: 1 | 2,
  dateTime: Date
}

export interface sendMessageResponse
{
  df: string
  fig: string
  id: string
  text: string
  type: string
}

//here 1 means user and 2 means api
