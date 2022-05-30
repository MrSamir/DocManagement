import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { document } from '../models/document';

@Injectable({
    providedIn: 'root'
})
export class documentService {
    constructor(private _http: HttpClient) { }
    private readonly Api_Url: string = environment.API_URL;
    private readonly controllerName: string = 'document/';





    //#region  CRUD
    getAlldocuments() {
        return this._http.get<document[]>(this.Api_Url + this.controllerName + 'Select_documents');
    }

    deletedocument(id: number) {
        return this._http.get<document>(this.Api_Url + this.controllerName + 'Delete_document?ID=' + id);
    }


    adddocument(document: document) {
        return this._http.post<document[]>(this.Api_Url + this.controllerName + 'Insert_document/', document);
    }
    updatedocument(document: document) {
        return this._http.put<document[]>(this.Api_Url + this.controllerName + 'Update_document', document);
    }
    //#endregion


}
