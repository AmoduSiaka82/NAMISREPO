using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NAMIS.ViewModels
{
    public class UsersTabViewModel
    {
        public Tab ActiveTab { get; set; }
        public TabN ActiveTabN { get; set; }
        public TabL ActiveTabL { get; set; }
        public TabC ActiveTabC { get; set; }
        public TabP ActiveTabP { get; set; }
        public TabM ActiveTabM { get; set; }
        public TabR ActiveTabR { get; set; }
        public TabF ActiveTabF { get; set; }
        public TabT ActiveTabT { get; set; }
        public TabI ActiveTabI { get; set; }
        public TabRPT ActiveTabRPT { get; set; }
        public TabMe ActiveTabMe { get; set; }
        public TabRANDM ActiveTabRANDM { get; set; }
        public TabV ActiveTabV { get; set; }
        public TabD ActiveTabD { get; set; }
    }
    public enum Tab
    {
        PreparePromotion,
        Qaulified,
        Disaulified,
        Promoted
    }
    public enum TabN
    {
       Norminal
       
    }

    public enum TabRANDM
    {
        LetterHead,
        PrintMemo

    }
    public enum TabV
    {
        Variation,
        VariationList,
        ApprovedVariation


    }
    public enum TabD
    {
        Disposition,
        DispositionList,
        ApprovedDisposition

    }
    public enum TabM
    {
        MonthlyReturn,
        PreparedMonthlyReturn
            
            
    }
    public enum TabR
    {
        PrepareRetirmentList,
        PrepareRetirmentRoll,
        ApprovedRetirment,
        WastedRegister

    }
    public enum TabL
    {
        LeaveRoaster,
        PreparedLeave,
        ApprovedLeave,
        WrittenLetter

    }

    public enum TabC
    {
       ConfirmationList,
        PreparedComfirmation,
        ApprovedConfirmation,
        WrittenConfirmationLetter

    }
    public enum TabP
    {
        PostingList,
        PreparedPosting,
        ApprovedPosting,
        WrittenPostingLetter

    }
    public enum TabF
    {
        FileList,
        PreparedFile,
        ApprovedPersonnelFile

    }
    public enum TabMe
    {
        PreparedMemo,
        ApprovedMemo,

        ApprovedMemoLetter

    }
    public enum TabRPT
    {
        PreparedRPT,
        ApprovedRPT,

        ApprovedRPTLetter,
        PreparedMemo,
        ApprovedMemo,

        ApprovedMemoLetter

    }
        public enum TabI
    {
        PreparedIt,
        ApprovedIt,
        
        ApprovedLetter

    }
    public enum TabT
    {
        StaffOnTrainingList,
        PreparedStaffOnTraining,
        ApprovedStaffOnTraining,
        ReleaseLetter

    }
    
}
