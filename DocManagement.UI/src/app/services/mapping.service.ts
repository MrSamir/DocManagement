import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { mapping } from '../models/mapping';

@Injectable({
    providedIn: 'root'
})
export class MappingService {
    constructor(private _http: HttpClient) { }
    private readonly Api_Url: string = environment.API_URL;
    private readonly controllerName: string = 'Mapping/';




    getMappingsByKeyword(keywordID: number) {


        return this._http.get<mapping[]>(this.Api_Url + this.controllerName + 'Select_Mappings_By_KeywordID?KeywordID=' + keywordID);
    }


    //#region  CRUD
    getAllMappings() {
        return this._http.get<mapping[]>(this.Api_Url + this.controllerName + 'Select_Mappings');
    }




    deleteMapping(id: number) {
        return this._http.get<mapping>(this.Api_Url + this.controllerName + 'Delete_Mapping?ID=' + id);
    }


    addMapping(mapping: mapping) {
        return this._http.post<mapping[]>(this.Api_Url + this.controllerName + 'Insert_Mapping/', mapping);
    }
    updateMapping(mapping: mapping) {
        // return this._http.put<mapping[]>(this.Api_Url + this.controllerName + 'Update_Mapping', mapping);
        return this._http.put<mapping[]>(this.Api_Url + this.controllerName + 'Update_Mapping', mapping);
    }



    //#endregion


}
