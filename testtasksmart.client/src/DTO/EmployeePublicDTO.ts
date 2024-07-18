import { SubdivisionDTO } from './SubdivisionDTO';
import { PositionDTO } from './PositionDTO';
import { PartnerDTO } from './PartnerDTO';

export interface PublicEmployeeDTO {
  id: number;
  fullName: string;
  subdivision: SubdivisionDTO;
  position: PositionDTO;
  status: boolean;
  peoplePartner: PartnerDTO;
  balance: number;
}
