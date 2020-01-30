import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';  
import { airplane } from './airplane'; 

var httpOptions = {headers: new HttpHeaders({"Content-Type": "application/json"})};

@Injectable({
  providedIn: 'root'
})
export class airplaneService {

  url = 'https://localhost:44399/api/airplanes';  

  constructor(private http: HttpClient) { }

  getAllairplanes(): Observable<airplane[]> {  
    return this.http.get<airplane[]>(this.url);  
  }  

  getairplaneById(airplaneid: string): Observable<airplane> {  
    const apiurl = `${this.url}/${airplaneid}`;
    return this.http.get<airplane>(apiurl);  
  } 

  createairplane(airplane: airplane): Observable<airplane> {  
    return this.http.post<airplane>(this.url, airplane, httpOptions);  
  }  

  updateairplane(airplaneid: string, airplane: airplane): Observable<airplane> {  
    const apiurl = `${this.url}/${airplaneid}`;
    return this.http.put<airplane>(apiurl,airplane, httpOptions);  
  }  

  deleteairplaneById(airplaneid: string): Observable<number> {  
    const apiurl = `${this.url}/${airplaneid}`;
    return this.http.delete<number>(apiurl, httpOptions);  
  }  
}
