import { SatelliteCoordinates } from "./satellite-coordinates.type";

export interface Satellite{
    iss_position:SatelliteCoordinates;
    timestamp:number;
    message:string;
}


 