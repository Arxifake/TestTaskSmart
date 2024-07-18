import { LeaveRequest } from './LeaveRequest';
import { PartnerDTO } from './PartnerDTO';

export interface ApprovalRequest {
  id: number;
  formattedId: string;
  employee: PartnerDTO;
  comment: string;
  status: string;
  leaveRequest: LeaveRequest;
  isSubmited: boolean;
}
