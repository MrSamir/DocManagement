import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { keyword } from '../models/keyword';

@Injectable({
    providedIn: 'root'
})
export class keywordService {
    constructor(private _http: HttpClient) { }
    private readonly Api_Url: string = environment.API_URL;
    private readonly controllerName: string = 'keyword/';





    //#region  CRUD
    getAllkeywords() {
        return this._http.get<keyword[]>(this.Api_Url + this.controllerName + 'Select_keywords');
    }

    deletekeyword(id: number) {
        return this._http.get<keyword>(this.Api_Url + this.controllerName + 'Delete_keyword?ID=' + id);
    }


    addkeyword(keyword: string) {
        return this._http.get<keyword[]>(this.Api_Url + this.controllerName + 'Insert_keyword?name=' + keyword);
    }
    updatekeyword(keyword: keyword) {
        return this._http.put<keyword[]>(this.Api_Url + this.controllerName + 'Update_keyword', keyword);
    }
    //#endregion


}
