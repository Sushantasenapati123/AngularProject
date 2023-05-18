import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http'
import { Observable } from 'rxjs';
import { Product } from './product/enitiy.model';

@Injectable({
  providedIn: 'root'
})
export class HttpserviceService {

  constructor(private http:HttpClient) { }
  readonly BaseURI = 'http://localhost:11794/api';

getAllSectors(){
  return this.http.get<any>(this.BaseURI + '/Product')
}
Delete(pid): Observable<any> {

  return this.http.delete<any>(this.BaseURI + '/Product/'+pid);

}
Add(addData:Product): Observable<any> {
  return this.http.put<any>(this.BaseURI +'/Product/'+addData.pid,
addData);

}
ShowOne(pid): Observable<any[]> {
debugger;
  return this.http.get<any[]>(this.BaseURI + '/Product/'+
  pid);

}


}



