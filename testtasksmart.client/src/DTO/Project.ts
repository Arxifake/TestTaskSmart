import { PartnerDTO } from "./PartnerDTO";

export interface Project {
  id: number;
  formattedId: string;
  type: string;
  startDate: Date;
  endDate: Date;
  projectManager: PartnerDTO;
  comment: string;
  status: boolean;
}
