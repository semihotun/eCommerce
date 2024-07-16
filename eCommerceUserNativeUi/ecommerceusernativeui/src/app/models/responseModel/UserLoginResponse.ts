export interface UserLoginResponse {
  claims: Claim[];
  token: string;
  expiration: string;
  id: string;
}
export interface Claim {
  claimType: string;
  value: string;
}
