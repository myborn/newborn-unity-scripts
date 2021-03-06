﻿using UnityEngine;

public class ApiConfig : ScriptableObject
{
  public static string url = "https://sw2hs7ufb5gevarvuyswhrndjm.appsync-api.eu-west-1.amazonaws.com/graphql";
  public static string apiKey = "da2-5aipqbxwx5eyfkoain3jhxtigm";
  public static string generationsGraphQlQuery = "query getGenerations {listGenerations { items {id} }}";
  public static string generationsGraphQlMutation = "mutation createGeneration {createGeneration(input: {id: $id^, index: $index^}) { id, index }}";
  public static string newbornGraphQlMutation = "mutation NewbornPost {createNewborn(input: {id: '$id^', name: $name^, sex: $sex^, newbornGenerationId: '$newbornGenerationId^'}) {id, name, sex, childs, parents, generation{index}}}";
  public static string postNewbornFromReproductionGraphQlMutation = "mutation NewbornPost {createNewborn(input: {id: $id^, name: $name^, sex: $sex^, newbornGenerationId: $newbornGenerationId^, parents:['$parentA^', '$parentB^']}) {id, name, generation{index}}}";
  public static string newbornsGraphQlQuery = "query NewbornsQuery {listNewborns(filter: {training: {eq: false}, living: {eq: false}}, limit: 1000) {items {id, parents}}}";
  public static string modelGraphQlMutation = "mutation ModelPost {createModel(input: {id: '$id^', cellInfos: $cellInfos^, cellPositions: $cellPositions^, cellPaths: $cellPaths^, modelNewbornId: '$modelNewbornId^'}) { id, cellInfos, cellPaths }}";
  public static string newBornGraphQlQuery = "query getNewBorn {getNewborn(id: '$id^') { id, name, sex, childs, parents, models { items { cellInfos, cellPaths } }, generation { id, index }  }}";
  public static string trainingGraphQlQuery = "query GetPost {start(newbornId: '$id^')}";
  public static string updateNewbornInstanceId = "mutation UpdateNewbornInstanceId {updateNewborn(input: {id: '$id^', instanceId: $instanceId^}) { id, instanceId }}";
  public static string updateNewbornChildsAndPartners = "mutation updateNewbornChilds {updateNewborn(input: {id: '$id^', childs: [$childs^], partners: [$partners^]}) { id }}";
  public static string updateTrainedStatus = "mutation UpdateTrainedStatus {updateNewborn(input: {id: '$id^', training: $status^}) { id }}";
  public static string updateTrainingStageQuery = "mutation updateNewbornTrainingStage {updateNewborn(input: {id: '$id^', trainingStage: '$stage^'}) { id }}";
  public static string updateLivingStatusQuery = "mutation updateNewbornLivingStatus {updateNewborn(input: {id: '$id^', living: '$status^'}) { id }}";
  public static string updateTrainerData = "query updateTrainerData {updateTrainer(trainerKey: $key^, trainerData: $data^)}";
  public static string downloadTrainerData = "query update {downloadTrainer(trainerKey: $key^)}";
}