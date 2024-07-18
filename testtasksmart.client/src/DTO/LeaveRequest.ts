import { PartnerDTO } from './PartnerDTO';

export interface LeaveRequest {
  id: number;
  formattedId: string;
  employee?: PartnerDTO;
  comment: string;
  status: string;
  absenceReason: string;
  startDate: Date;
  endDate: Date;
}
